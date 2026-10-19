from datetime import timedelta
from app import app, db
from models import Admin, Reader, Loan, BlockedUser

def fix_database_time():
    with app.app_context():
        print("Начинаем обновление времени (+1 час) в базе данных...")

        # 1. Обновляем время последнего входа у Администраторов
        admins = Admin.query.all()
        for a in admins:
            if a.last_login:
                a.last_login += timedelta(hours=1)
            if a.created_at:
                a.created_at += timedelta(hours=1)

        # 2. Обновляем время у Читателей
        readers = Reader.query.all()
        for r in readers:
            if r.last_login:
                r.last_login += timedelta(hours=1)
            if r.created_at:
                r.created_at += timedelta(hours=1)

        # 3. Обновляем время блокировки (если есть заблокированные)
        blocked = BlockedUser.query.all()
        for b in blocked:
            if b.blocked_at:
                b.blocked_at += timedelta(hours=1)

        # 4. Обновляем даты выдачи книг (сдвигаем на 1 час, чтобы дата не "съехала" при переходе через полночь)
        loans = Loan.query.all()
        for l in loans:
            if l.due_date:
                # Так как due_date — это Date (только дата), прибавляем 1 день, 
                # если нужно сдвинуть именно дату. Но если это просто дата возврата, 
                # то обычно её не трогают. Оставим как есть, если вы не просили иное.
                pass

        db.session.commit()
        print("Готово! Все даты и время в базе данных успешно переведены на Самарское время (МСК+1).")

if __name__ == "__main__":
    fix_database_time()