# projektAspNet
Aplikacja służąca do zarządzania spływami kajakowaymi. Umożliwia zwykłym zalogowanym użytkownikom tworzenie rezerwacji, profilu klienta. Ponadto wyświetlanie
tras i ciekawych wydarzeń. Reszta akcji jest możliwa z uprawnieniami administratora. Aplikacja wykorzystuje ASP.NET MVC oraz Microsoft SQL Server
Managment Studio. Wykorzystuje także moduł identity do autoryzacji użytkowników. Dane powinny zostać wysłane do bazy po wpisaniu w Konsoli menadżera 
pakietów komend:

add-migration initialCreate -context AppDbContext

update-database -context AppDbContext.

Aby działał moduł identity w konsoli menadżera pakietów należy wpisać komendy:

add-migration initialIdentity -context IdentityDbContext

update-database -context IdentityDbContext

Domyślne konto z uprawnieniami administratora:
login: wojtek.nowak@wp.pl   hasło: zaq1@WSX
