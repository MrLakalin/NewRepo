import random
from datetime import date, timedelta
from functools import wraps

from flask import (
    Flask, render_template, request, redirect,
    url_for, flash, abort
)
from flask_login import (
    LoginManager, login_user, logout_user,
    login_required, current_user
)

from models import db, Admin, Reader, Book, Loan, Role, BlockedUser


# =========================================================
# 1. Приложение и конфиг
# =========================================================
app = Flask(__name__)
app.config["SECRET_KEY"] = "change-me-to-random-secret-key"
app.config["SQLALCHEMY_DATABASE_URI"] = "sqlite:///library.db"
app.config["SQLALCHEMY_TRACK_MODIFICATIONS"] = False

db.init_app(app)


# =========================================================
# 2. Flask-Login
# =========================================================
login_manager = LoginManager()
login_manager.init_app(app)
login_manager.login_view = "login"
login_manager.login_message = "Пожалуйста, войдите в систему."
login_manager.login_message_category = "warning"


@login_manager.user_loader
def load_user(user_id: str):
    """
    ID в сессии имеет вид «admin_1» или «reader_5»,
    чтобы Flask-Login понимал, из какой таблицы грузить.
    """
    if not user_id or "_" not in user_id:
        return None

    kind, raw_id = user_id.split("_", 1)
    try:
        pk = int(raw_id)
    except ValueError:
        return None

    if kind == "admin":
        return db.session.get(Admin, pk)
    if kind == "reader":
        return db.session.get(Reader, pk)
    return None


# Префиксы для get_id(), чтобы различать админа и читателя
Admin.get_id = lambda self: f"admin_{self.id}"
Reader.get_id = lambda self: f"reader_{self.id}"


# =========================================================
# 3. Декоратор: только администратор
# =========================================================
def admin_required(view):
    @wraps(view)
    def wrapper(*args, **kwargs):
        if not current_user.is_authenticated:
            return redirect(url_for("login"))
        if not current_user.is_admin:
            flash(
                "Доступ запрещён. Требуются права администратора.",
                "danger",
            )
            return redirect(url_for("cabinet"))
        return view(*args, **kwargs)
    return wrapper


# =========================================================
# 4. Утилиты для работы с телефоном
# =========================================================
def normalize_phone(raw: str) -> str:
    """Оставляет только цифры; сохраняет ведущий «+», если он был."""
    if not raw:
        return ""
    raw = raw.strip()
    digits = "".join(ch for ch in raw if ch.isdigit())
    if raw.startswith("+"):
        return "+" + digits
    return digits


def is_valid_phone(phone: str) -> bool:
    """Проверяет, что телефон — 10–15 цифр (без учёта ведущего «+»)."""
    digits = phone.lstrip("+")
    return digits.isdigit() and 10 <= len(digits) <= 15


def find_account_by_phone(phone_value: str):
    """
    Ищет учётную запись по номеру телефона в обеих таблицах.
    Возвращает (user, kind) или (None, None).
    """
    admin = Admin.query.filter_by(phone=phone_value).first()
    if admin:
        return admin, "admin"

    reader = Reader.query.filter_by(phone=phone_value).first()
    if reader:
        return reader, "reader"

    return None, None


# =========================================================
# 5. Инициализация БД (без тестовых пользователей)
# =========================================================
def seed():
    if Book.query.count() == 0:
        books = [
            Book(
                title="Преступление и наказание",
                author="Фёдор Достоевский",
                genre="Классика",
                year=1866,
                description=(
                    "Социально-философский роман о морали и грехе. "
                    "История студента Родиона Раскольникова."
                ),
                cover_url="https://covers.openlibrary.org/b/isbn/9780143058144-L.jpg",
            ),
            Book(
                title="Мастер и Маргарита",
                author="Михаил Булгаков",
                genre="Классика",
                year=1967,
                description=(
                    "Роман о добре и зле, любви и трусости, "
                    "написанный с неповторимой иронией и мистикой."
                ),
                cover_url="https://covers.openlibrary.org/b/isbn/9780143108276-L.jpg",
            ),
            Book(
                title="1984",
                author="Джордж Оруэлл",
                genre="Антиутопия",
                year=1949,
                description=(
                    "Классическая антиутопия о тотальном контроле "
                    "и свободе мысли."
                ),
                cover_url="https://covers.openlibrary.org/b/isbn/9780451524935-L.jpg",
            ),
            Book(
                title="Война и мир",
                author="Лев Толстой",
                genre="Классика",
                year=1869,
                description=(
                    "Эпопея о русском обществе в эпоху войн "
                    "против Наполеона."
                ),
                cover_url="https://covers.openlibrary.org/b/isbn/9780199232765-L.jpg",
            ),
            Book(
                title="Анна Каренина",
                author="Лев Толстой",
                genre="Классика",
                year=1877,
                description=(
                    "Трагическая история любви замужней женщины "
                    "Анны Карениной."
                ),
                cover_url="https://covers.openlibrary.org/b/isbn/9780143035008-L.jpg",
            ),
            Book(
                title="Идиот",
                author="Фёдор Достоевский",
                genre="Классика",
                year=1869,
                description=(
                    "История князя Мышкина — «положительно "
                    "прекрасного человека»."
                ),
                cover_url="https://covers.openlibrary.org/b/isbn/9780140447927-L.jpg",
            ),
            Book(
                title="Тихий Дон",
                author="Михаил Шолохов",
                genre="Классика",
                year=1940,
                description=(
                    "Эпопея о судьбе донского казачества "
                    "в годы войны и революции."
                ),
                cover_url="https://covers.openlibrary.org/b/isbn/9781477842452-L.jpg",
            ),
            Book(
                title="Собачье сердце",
                author="Михаил Булгаков",
                genre="Сатира",
                year=1925,
                description=(
                    "Сатирическая повесть о профессоре Преображенском "
                    "и его эксперименте."
                ),
                cover_url="https://covers.openlibrary.org/b/isbn/9780810116795-L.jpg",
            ),
            Book(
                title="Гарри Поттер и философский камень",
                author="Джоан Роулинг",
                genre="Фэнтези",
                year=1997,
                description=(
                    "Первая книга о юном волшебнике Гарри Поттере "
                    "и школе Хогвартс."
                ),
                cover_url="https://covers.openlibrary.org/b/isbn/9780747532699-L.jpg",
            ),
            Book(
                title="Властелин колец",
                author="Дж. Р. Р. Толкин",
                genre="Фэнтези",
                year=1954,
                description=(
                    "Эпическая сага о Средиземье, кольце Всевластия "
                    "и хоббите Фродо."
                ),
                cover_url="https://covers.openlibrary.org/b/isbn/9780618640157-L.jpg",
            ),
            Book(
                title="Дюна",
                author="Фрэнк Герберт",
                genre="Фантастика",
                year=1965,
                description=(
                    "Научно-фантастический роман о пустынной планете "
                    "Арракис и специи."
                ),
                cover_url="https://covers.openlibrary.org/b/isbn/9780441172719-L.jpg",
            ),
            Book(
                title="451° по Фаренгейту",
                author="Рэй Брэдбери",
                genre="Антиутопия",
                year=1953,
                description=(
                    "Роман о мире, где книги сжигают, "
                    "а пожарные разжигают огонь."
                ),
                cover_url="https://covers.openlibrary.org/b/isbn/9781451673319-L.jpg",
            ),
            Book(
                title="Три товарища",
                author="Эрих Мария Ремарк",
                genre="Классика",
                year=1936,
                description=(
                    "Роман о дружбе и любви в послевоенной Германии."
                ),
                cover_url="https://covers.openlibrary.org/b/isbn/9780449912423-L.jpg",
            ),
        ]
        db.session.add_all(books)
        db.session.commit()


with app.app_context():
    db.create_all()
    seed()


# =========================================================
# 6. Публичные страницы
# =========================================================
@app.route("/")
def index():
    books = Book.query.limit(4).all()
    return render_template("index.html", books=books)


@app.route("/catalog")
def catalog():
    q = request.args.get("q", "").strip()
    genre = request.args.get("genre")

    query = Book.query
    if q:
        like = f"%{q}%"
        query = query.filter(
            (Book.title.ilike(like)) |
            (Book.author.ilike(like)) |
            (Book.genre.ilike(like))
        )
    if genre:
        query = query.filter_by(genre=genre)

    books = query.all()
    genres = [
        g[0] for g in db.session.query(Book.genre).distinct().all() if g[0]
    ]
    return render_template(
        "catalog.html",
        books=books,
        genres=genres,
        active_genre=genre,
        query=q,
    )


@app.route("/book/<int:book_id>")
def book_detail(book_id: int):
    book = db.session.get(Book, book_id)
    if book is None:
        abort(404)
    return render_template("book.html", book=book)


# =========================================================
# 7. Авторизация
# =========================================================
@app.route("/login", methods=["GET", "POST"])
def login():
    if current_user.is_authenticated:
        if current_user.must_change_password:
            return redirect(url_for("change_password"))
        return redirect(url_for("cabinet"))

    if request.method == "POST":
        phone_value = normalize_phone(request.form.get("phone", ""))
        password = request.form.get("password", "")

        if not phone_value or not password:
            flash(
                "Поля «Номер телефона» и «Пароль» "
                "обязательны для заполнения.",
                "danger",
            )
            return render_template("login.html")

        account, kind = find_account_by_phone(phone_value)

        if account is None:
            flash(
                "Вы ввели неверный номер телефона или пароль. "
                "Пожалуйста проверьте ещё раз введенные данные",
                "danger",
            )
            return render_template("login.html")

        if account.is_blocked:
            flash("Вы заблокированы. Обратитесь к администратору", "danger")
            return render_template("login.html")

        if account.is_inactive_for_month():
            account.is_blocked = True
            account._add_to_blocked_table()
            db.session.commit()
            flash("Вы заблокированы. Обратитесь к администратору", "danger")
            return render_template("login.html")

        if not account.check_password(password):
            account.register_failed_attempt()
            db.session.commit()

            if account.is_blocked:
                flash(
                    "Вы заблокированы. Обратитесь к администратору",
                    "danger",
                )
            else:
                remaining = 3 - account.failed_attempts
                flash(
                    "Вы ввели неверный номер телефона или пароль. "
                    "Пожалуйста проверьте ещё раз введенные данные. "
                    f"Осталось попыток: {remaining}",
                    "danger",
                )
            return render_template("login.html")

        account.reset_failed_attempts()
        account.touch_last_login()
        db.session.commit()

        login_user(account, remember=True)
        flash("Вы успешно авторизовались", "success")

        if account.must_change_password:
            return redirect(url_for("change_password"))

        return redirect(url_for("cabinet"))

    return render_template("login.html")


# =========================================================
# 8. Регистрация (создаёт только читателя)
# =========================================================
@app.route("/register", methods=["GET", "POST"])
def register():
    if current_user.is_authenticated:
        return redirect(url_for("cabinet"))

    if request.method == "POST":
        phone_value = normalize_phone(request.form.get("phone", ""))
        password = request.form.get("password", "")
        confirm = request.form.get("confirm_password", "")

        errors = []
        if not phone_value or not password or not confirm:
            errors.append("Все поля обязательны для заполнения.")
        if phone_value and not is_valid_phone(phone_value):
            errors.append("Номер телефона должен содержать 10–15 цифр.")
        if password and len(password) < 6:
            errors.append("Пароль должен содержать минимум 6 символов.")
        if password and confirm and password != confirm:
            errors.append("Пароль и повторный пароль не совпадают.")

        # Проверка уникальности телефона в обеих таблицах
        if phone_value:
            if Admin.query.filter_by(phone=phone_value).first():
                errors.append(
                    "Пользователь с таким номером телефона уже существует."
                )
            if Reader.query.filter_by(phone=phone_value).first():
                errors.append(
                    "Пользователь с таким номером телефона уже существует."
                )

        if errors:
            for e in errors:
                flash(e, "danger")
            return render_template("register.html", form_data=request.form)

        reader = Reader(
            full_name="Читатель",
            phone=phone_value,
            must_change_password=False,
        )
        reader.set_password(password)
        reader.reset_failed_attempts()
        db.session.add(reader)
        db.session.commit()

        flash(
            "Регистрация успешна! Теперь войдите "
            "под своим номером телефона.",
            "success",
        )
        return redirect(url_for("login"))

    return render_template("register.html", form_data={})


# =========================================================
# 9. Смена пароля
# =========================================================
@app.route("/change-password", methods=["GET", "POST"])
@login_required
def change_password():
    if request.method == "POST":
        current = request.form.get("current_password", "")
        new = request.form.get("new_password", "")
        confirm = request.form.get("confirm_password", "")

        errors = []
        if not current or not new or not confirm:
            errors.append("Все поля обязательны для заполнения.")
        if current and not current_user.check_password(current):
            errors.append("Текущий пароль введён неверно.")
        if new and confirm and new != confirm:
            errors.append("Новый пароль и подтверждение не совпадают.")
        if new and len(new) < 6:
            errors.append("Новый пароль должен содержать минимум 6 символов.")
        if new and new == current:
            errors.append("Новый пароль должен отличаться от текущего.")

        if errors:
            for e in errors:
                flash(e, "danger")
            return render_template("change_password.html")

        current_user.set_password(new)
        current_user.must_change_password = False
        db.session.commit()

        flash("Пароль успешно изменён", "success")
        return redirect(url_for("cabinet"))

    return render_template("change_password.html")


@app.route("/logout")
@login_required
def logout():
    logout_user()
    flash("Вы вышли из системы.", "success")
    return redirect(url_for("index"))


# =========================================================
# 10. Кабинет
# =========================================================
@app.route("/cabinet")
@login_required
def cabinet():
    if current_user.must_change_password:
        return redirect(url_for("change_password"))

    if current_user.is_admin:
        return redirect(url_for("admin_users"))

    loans = Loan.query.filter_by(
        reader_id=current_user.id, returned=False
    ).all()
    return render_template("cabinet.html", loans=loans, today=date.today())

@app.route("/cabinet/edit-name", methods=["GET", "POST"])
@login_required
def cabinet_edit_name():
    if current_user.is_admin:
        return redirect(url_for("cabinet"))

    if request.method == "POST":
        full_name = request.form.get("full_name", "").strip()

        if not full_name:
            flash("ФИО обязательно для заполнения.", "danger")
            return render_template("cabinet_edit_name.html")

        if len(full_name) < 3:
            flash("ФИО должно содержать минимум 3 символа.", "danger")
            return render_template("cabinet_edit_name.html")

        current_user.full_name = full_name
        db.session.commit()

        flash("ФИО успешно изменено.", "success")
        return redirect(url_for("cabinet"))

    return render_template("cabinet_edit_name.html")


# =========================================================
# Личный кабинет: смена пароля (для читателя)
# =========================================================
@app.route("/cabinet/change-password", methods=["GET", "POST"])
@login_required
def cabinet_change_password():
    if current_user.is_admin:
        return redirect(url_for("cabinet"))

    if request.method == "POST":
        current = request.form.get("current_password", "")
        new = request.form.get("new_password", "")
        confirm = request.form.get("confirm_password", "")

        errors = []
        if not current or not new or not confirm:
            errors.append("Все поля обязательны для заполнения.")
        if current and not current_user.check_password(current):
            errors.append("Текущий пароль введён неверно.")
        if new and confirm and new != confirm:
            errors.append("Новый пароль и подтверждение не совпадают.")
        if new and len(new) < 6:
            errors.append("Новый пароль должен содержать минимум 6 символов.")
        if new and new == current:
            errors.append("Новый пароль должен отличаться от текущего.")

        if errors:
            for e in errors:
                flash(e, "danger")
            return render_template("cabinet_change_password.html")

        current_user.set_password(new)
        db.session.commit()

        flash("Пароль успешно изменён.", "success")
        return redirect(url_for("cabinet"))

    return render_template("cabinet_change_password.html")


# =========================================================
# Личный кабинет: отмена брони
# =========================================================
@app.route("/loan/<int:loan_id>/cancel", methods=["POST"])
@login_required
def cancel_loan(loan_id: int):
    loan = db.session.get(Loan, loan_id)
    if loan is None:
        abort(404)

    # Читатель может отменить только свою бронь
    if loan.reader_id != current_user.id and not current_user.is_admin:
        flash("Нет доступа к этой брони.", "danger")
        return redirect(url_for("cabinet"))

    book = loan.book
    book.available = True
    db.session.delete(loan)
    db.session.commit()

    flash(
        f"Бронь на книгу «{book.title}» отменена. "
        "Книга возвращена в фонд.",
        "success",
    )
    return redirect(url_for("cabinet"))

@app.route("/book/<int:book_id>/reserve", methods=["POST"])
@login_required
def reserve(book_id: int):
    if current_user.is_admin:
        flash("Администратор не бронирует книги.", "warning")
        return redirect(url_for("book_detail", book_id=book_id))

    book = db.session.get(Book, book_id)
    if book is None:
        abort(404)

    if not book.available:
        flash("Книга уже забронирована.", "danger")
        return redirect(url_for("book_detail", book_id=book.id))

    loan = Loan(
        reader_id=current_user.id,
        book_id=book.id,
        due_date=date.today() + timedelta(days=14),
    )
    book.available = False
    db.session.add(loan)
    db.session.commit()

    flash(
        "Книга успешно забронирована! Заберите её в течение 3 дней.",
        "success",
    )
    return redirect(url_for("cabinet"))


# =========================================================
# 11. Панель администратора — управление ЧИТАТЕЛЯМИ
# =========================================================
@app.route("/admin/readers")
@admin_required
def admin_users():
    readers = Reader.query.order_by(Reader.id).all()
    return render_template("admin/users.html", readers=readers)


@app.route("/admin/readers/new", methods=["GET", "POST"])
@admin_required
def admin_user_new():
    if request.method == "POST":
        phone_value = normalize_phone(request.form.get("phone", ""))
        password = request.form.get("password", "")
        full_name = request.form.get("full_name", "").strip() or "Читатель"

        errors = []
        if not phone_value or not password:
            errors.append("Телефон и пароль обязательны для заполнения.")
        if phone_value and not is_valid_phone(phone_value):
            errors.append("Номер телефона должен содержать 10–15 цифр.")
        if len(password) < 6:
            errors.append("Пароль должен содержать минимум 6 символов.")
        if phone_value and Reader.query.filter_by(phone=phone_value).first():
            errors.append(
                "Читатель с таким номером телефона уже существует."
            )
        if phone_value and Admin.query.filter_by(phone=phone_value).first():
            errors.append(
                "Пользователь с таким номером телефона уже существует."
            )

        if errors:
            for e in errors:
                flash(e, "danger")
            return render_template(
                "admin/user_form.html",
                form_data=request.form,
            )

        reader = Reader(
            full_name=full_name,
            phone=phone_value,
            must_change_password=True,
        )
        reader.set_password(password)
        db.session.add(reader)
        db.session.commit()

        flash(
            f"Читатель с телефоном {phone_value} добавлен. "
            "При первом входе он должен сменить пароль.",
            "success",
        )
        return redirect(url_for("admin_users"))

    return render_template("admin/user_form.html", form_data={})


@app.route("/admin/readers/<int:reader_id>/edit", methods=["GET", "POST"])
@admin_required
def admin_user_edit(reader_id: int):
    reader = db.session.get(Reader, reader_id)
    if reader is None:
        abort(404)

    if request.method == "POST":
        full_name = request.form.get("full_name", "").strip()

        errors = []
        if not full_name:
            errors.append("ФИО обязательно для заполнения.")

        if errors:
            for e in errors:
                flash(e, "danger")
            return render_template("admin/user_edit.html", reader=reader)

        reader.full_name = full_name

        if request.form.get("reset_password") == "1":
            new_password = request.form.get("new_password", "")
            if len(new_password) < 6:
                flash(
                    "Новый пароль должен содержать минимум 6 символов.",
                    "danger",
                )
                return render_template(
                    "admin/user_edit.html", reader=reader
                )
            reader.set_password(new_password)
            reader.must_change_password = True
            flash(
                "Пароль сброшен. При следующем входе читатель "
                "должен сменить его.",
                "success",
            )

        db.session.commit()
        flash("Данные читателя сохранены.", "success")
        return redirect(url_for("admin_users"))

    return render_template("admin/user_edit.html", reader=reader)


@app.route("/admin/readers/<int:reader_id>/delete", methods=["POST"])
@admin_required
def admin_user_delete(reader_id: int):
    reader = db.session.get(Reader, reader_id)
    if reader is None:
        abort(404)

    phone = reader.phone

    # Удаляем запись о блокировке (если есть)
    BlockedUser.query.filter_by(
        user_kind="reader", user_id=reader.id
    ).delete(synchronize_session=False)

    db.session.delete(reader)
    db.session.commit()
    flash(f"Читатель {phone} удалён.", "success")
    return redirect(url_for("admin_users"))


# =========================================================
# 12. Панель администратора — управление АДМИНАМИ
# =========================================================
@app.route("/admin/admins")
@admin_required
def admin_admins():
    admins = Admin.query.order_by(Admin.id).all()
    return render_template("admin/admins.html", admins=admins)


@app.route("/admin/admins/new", methods=["GET", "POST"])
@admin_required
def admin_admin_new():
    if request.method == "POST":
        phone_value = normalize_phone(request.form.get("phone", ""))
        password = request.form.get("password", "")
        full_name = (
            request.form.get("full_name", "").strip() or "Администратор"
        )

        errors = []
        if not phone_value or not password:
            errors.append("Телефон и пароль обязательны для заполнения.")
        if phone_value and not is_valid_phone(phone_value):
            errors.append("Номер телефона должен содержать 10–15 цифр.")
        if len(password) < 6:
            errors.append("Пароль должен содержать минимум 6 символов.")
        if phone_value and Admin.query.filter_by(phone=phone_value).first():
            errors.append(
                "Администратор с таким номером телефона уже существует."
            )
        if phone_value and Reader.query.filter_by(phone=phone_value).first():
            errors.append(
                "Пользователь с таким номером телефона уже существует."
            )

        if errors:
            for e in errors:
                flash(e, "danger")
            return render_template(
                "admin/admin_form.html",
                form_data=request.form,
            )

        admin = Admin(
            full_name=full_name,
            phone=phone_value,
            must_change_password=True,
        )
        admin.set_password(password)
        db.session.add(admin)
        db.session.commit()

        flash(
            f"Администратор с телефоном {phone_value} добавлен. "
            "При первом входе он должен сменить пароль.",
            "success",
        )
        return redirect(url_for("admin_admins"))

    return render_template("admin/admin_form.html", form_data={})


@app.route("/admin/admins/<int:admin_id>/edit", methods=["GET", "POST"])
@admin_required
def admin_admin_edit(admin_id: int):
    admin = db.session.get(Admin, admin_id)
    if admin is None:
        abort(404)

    if request.method == "POST":
        full_name = request.form.get("full_name", "").strip()

        errors = []
        if not full_name:
            errors.append("ФИО обязательно для заполнения.")

        if errors:
            for e in errors:
                flash(e, "danger")
            return render_template("admin/admin_edit.html", admin=admin)

        admin.full_name = full_name

        if request.form.get("reset_password") == "1":
            new_password = request.form.get("new_password", "")
            if len(new_password) < 6:
                flash(
                    "Новый пароль должен содержать минимум 6 символов.",
                    "danger",
                )
                return render_template(
                    "admin/admin_edit.html", admin=admin
                )
            admin.set_password(new_password)
            admin.must_change_password = True
            flash(
                "Пароль сброшен. При следующем входе администратор "
                "должен сменить его.",
                "success",
            )

        db.session.commit()
        flash("Данные администратора сохранены.", "success")
        return redirect(url_for("admin_admins"))

    return render_template("admin/admin_edit.html", admin=admin)


@app.route("/admin/admins/<int:admin_id>/delete", methods=["POST"])
@admin_required
def admin_admin_delete(admin_id: int):
    admin = db.session.get(Admin, admin_id)
    if admin is None:
        abort(404)

    if admin.id == current_user.id:
        flash("Нельзя удалить собственную учётную запись.", "danger")
        return redirect(url_for("admin_admins"))

    phone = admin.phone

    # Удаляем запись о блокировке (если есть)
    BlockedUser.query.filter_by(
        user_kind="admin", user_id=admin.id
    ).delete(synchronize_session=False)

    db.session.delete(admin)
    db.session.commit()
    flash(f"Администратор {phone} удалён.", "success")
    return redirect(url_for("admin_admins"))


# =========================================================
# 13. Панель администратора — ЗАБЛОКИРОВАННЫЕ ПОЛЬЗОВАТЕЛИ
# =========================================================
@app.route("/admin/blocked")
@admin_required
def admin_blocked():
    blocked = BlockedUser.query.order_by(
        BlockedUser.blocked_at.desc()
    ).all()
    return render_template("admin/blocked.html", blocked=blocked)


@app.route("/admin/blocked/<int:blocked_id>/unblock", methods=["POST"])
@admin_required
def admin_blocked_unblock(blocked_id: int):
    record = db.session.get(BlockedUser, blocked_id)
    if record is None:
        abort(404)

    account = record.to_account()

    if account is None:
        # Пользователь уже удалён — просто чистим запись
        db.session.delete(record)
        db.session.commit()
        flash(
            "Учётная запись не найдена, запись о блокировке удалена.",
            "warning",
        )
        return redirect(url_for("admin_blocked"))

    phone = account.phone
    account.unblock()  # снимает is_blocked, сбрасывает попытки, чистит BlockedUser
    db.session.commit()

    flash(
        f"Пользователь {phone} разблокирован.",
        "success",
    )
    return redirect(url_for("admin_blocked"))


# =========================================================
# 14. Панель администратора — УПРАВЛЕНИЕ БРОНЯМИ И НАЛИЧИЕМ КНИГ
# =========================================================
@app.route("/admin/loans")
@admin_required
def admin_loans():
    # Получаем все активные брони (книги, которые сейчас у читателей)
    loans = Loan.query.filter_by(returned=False).all()
    
    # Получаем все книги, которые доступны в фонде
    available_books = Book.query.filter_by(available=True).all()
    
    # Передаем сегодняшнюю дату в шаблон (используем стандартный date.today())
    return render_template(
        "admin/loans.html", 
        loans=loans, 
        available_books=available_books,
        today=date.today()  # <-- Вот исправление
    )


@app.route("/admin/loans/<int:loan_id>/return", methods=["POST"])
@admin_required
def admin_loan_return(loan_id: int):
    """Отметка о возврате книги читателем (книга снова доступна)"""
    loan = db.session.get(Loan, loan_id)
    if loan is None:
        abort(404)

    book = loan.book
    book.available = True
    
    # Удаляем запись о брони или помечаем как возвращенную
    # (в вашей модели лучше удалить, т.к. в кабинете читателя они удаляются)
    db.session.delete(loan) 
    db.session.commit()

    flash(f"Книга «{book.title}» возвращена в фонд.", "success")
    return redirect(url_for("admin_loans"))


@app.route("/admin/books/<int:book_id>/toggle-availability", methods=["POST"])
@admin_required
def admin_book_toggle_availability(book_id: int):
    """Принудительная смена статуса книги (например, если она потеряна)"""
    book = db.session.get(Book, book_id)
    if book is None:
        abort(404)

    book.available = not book.available
    db.session.commit()

    status = "Доступна" if book.available else "Недоступна (списана/потеряна)"
    flash(f"Статус книги «{book.title}» изменён на: {status}.", "info")
    return redirect(url_for("admin_loans"))


# =========================================================
# 15. Точка входа
# =========================================================
if __name__ == "__main__":
    app.run(debug=True)