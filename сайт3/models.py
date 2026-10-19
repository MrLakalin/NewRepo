from datetime import datetime, timedelta

from flask_sqlalchemy import SQLAlchemy
from flask_login import UserMixin


db = SQLAlchemy()


class Role:
    ADMIN = "admin"
    USER = "user"


class AuthMixin:
    """Общие для Admin и Reader поля."""

    id = db.Column(db.Integer, primary_key=True)
    full_name = db.Column(db.String(150), nullable=False)
    phone = db.Column(db.String(20), unique=True, nullable=False, index=True)
    password_hash = db.Column(db.String(255), nullable=False)

    must_change_password = db.Column(db.Boolean, default=False)
    failed_attempts = db.Column(db.Integer, default=0)
    is_blocked = db.Column(db.Boolean, default=False)
    last_login = db.Column(db.DateTime, default=datetime.utcnow)
    created_at = db.Column(db.DateTime, default=datetime.utcnow)

    def set_password(self, password: str) -> None:
        # Пароль хранится в открытом виде (только для лабораторной!)
        self.password_hash = password

    def check_password(self, password: str) -> bool:
        return self.password_hash == password

    def register_failed_attempt(self) -> None:
        self.failed_attempts += 1
        if self.failed_attempts >= 3:
            self.is_blocked = True
            self._add_to_blocked_table()  # <-- ОБЯЗАТЕЛЬНО

    def reset_failed_attempts(self) -> None:
        self.failed_attempts = 0

    def touch_last_login(self) -> None:
        self.last_login = datetime.utcnow()

    def is_inactive_for_month(self) -> bool:
        if self.last_login is None:
            return False
        return datetime.utcnow() - self.last_login > timedelta(days=30)

    def _add_to_blocked_table(self) -> None:
        """Добавляет запись в таблицу blocked_users (если ещё нет)."""
        kind = self.role  # "admin" / "user"
        user_kind = "admin" if kind == "admin" else "reader"

        exists = BlockedUser.query.filter_by(
            user_kind=user_kind, user_id=self.id
        ).first()
        if exists:
            return

        db.session.add(BlockedUser(
            user_kind=user_kind,
            user_id=self.id,
            phone=self.phone,
            full_name=self.full_name,
            reason="3 неудачные попытки входа",
        ))

    def unblock(self) -> None:
        """Снимает блокировку и удаляет запись из blocked_users."""
        self.is_blocked = False
        self.failed_attempts = 0

        user_kind = "admin" if self.role == "admin" else "reader"
        BlockedUser.query.filter_by(
            user_kind=user_kind, user_id=self.id
        ).delete(synchronize_session=False)


class Admin(AuthMixin, UserMixin, db.Model):
    __tablename__ = "admins"

    @property
    def role(self) -> str:
        return Role.ADMIN

    @property
    def role_label(self) -> str:
        return "Администратор"

    @property
    def is_admin(self) -> bool:
        return True

    @property
    def identity_label(self) -> str:
        return f"Телефон: {self.phone}"


class Reader(AuthMixin, UserMixin, db.Model):
    __tablename__ = "readers"

    loans = db.relationship("Loan", backref="reader", lazy=True)

    @property
    def role(self) -> str:
        return Role.USER

    @property
    def role_label(self) -> str:
        return "Пользователь"

    @property
    def is_admin(self) -> bool:
        return False

    @property
    def identity_label(self) -> str:
        return f"Телефон: {self.phone}"


class Book(db.Model):
    __tablename__ = "books"

    id = db.Column(db.Integer, primary_key=True)
    title = db.Column(db.String(200), nullable=False)
    author = db.Column(db.String(150), nullable=False)
    genre = db.Column(db.String(100))
    year = db.Column(db.Integer)
    description = db.Column(db.Text)
    cover_url = db.Column(db.String(500))
    available = db.Column(db.Boolean, default=True)


class Loan(db.Model):
    __tablename__ = "loans"

    id = db.Column(db.Integer, primary_key=True)
    reader_id = db.Column(
        db.Integer, db.ForeignKey("readers.id"), nullable=False
    )
    book_id = db.Column(
        db.Integer, db.ForeignKey("books.id"), nullable=False
    )
    due_date = db.Column(db.Date, nullable=False)
    returned = db.Column(db.Boolean, default=False)

    book = db.relationship("Book")


# =========================================================
# ВАЖНО: Класс BlockedUser должен быть в самом конце!
# =========================================================
class BlockedUser(db.Model):
    """
    Отдельная таблица для заблокированных учётных записей.
    Хранит ссылку на пользователя (админ или читатель) и причину блокировки.
    """
    __tablename__ = "blocked_users"

    id = db.Column(db.Integer, primary_key=True)
    user_kind = db.Column(db.String(10), nullable=False)
    user_id = db.Column(db.Integer, nullable=False)
    phone = db.Column(db.String(20), nullable=False, index=True)
    full_name = db.Column(db.String(150), nullable=False)
    reason = db.Column(db.String(255), default="3 неудачные попытки входа")
    blocked_at = db.Column(db.DateTime, default=datetime.utcnow, nullable=False)

    __table_args__ = (
        db.UniqueConstraint("user_kind", "user_id", name="uq_blocked_user"),
    )

    @property
    def kind_label(self) -> str:
        return "Администратор" if self.user_kind == "admin" else "Читатель"

    def to_account(self):
        """Возвращает объект Admin или Reader, либо None."""
        if self.user_kind == "admin":
            return db.session.get(Admin, self.user_id)
        if self.user_kind == "reader":
            return db.session.get(Reader, self.user_id)
        return None     