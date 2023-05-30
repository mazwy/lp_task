/*
Ogólne dane o użytkownikach systemu, wyliczane na daną chwilę:
- id konta
- imię
- nazwisko
- data rejestracji (zaokrąglona do dnia)
- liczba wszystkich wypożyczonych filmów
- liczba filmów wypożyczonych w opcji a) (na liczbę dni)
- liczba filmów wypożyczonych w opcji b) (na liczbę seansów)
- łączny koszt wszystkich wypożyczonych filmów
- data ostatniego wypożyczenia (zaokrąglona do dnia)
- gatunek ostatniego wypożyczonego filmu
- liczba ulubionych filmów
- liczba ulubionych filmów, które przynajmniej raz użytkownik wypożyczył
- najczęściej wypożyczany gatunek – jeśli użytkownik wypożyczył taką samą liczbę filmów z więcej niż 1 gatunku, to podajemy ten gatunek który pierwsze wypożyczenie miał wcześniej
*/

SELECT 
    u.Id,
    u.FirstName, 
    u.LastName,
    CONVERT(
        date, 
        (SELECT start_time FROM sys.dm_exec_requests WHERE session_id = @@SPID), 
        112
    ) AS RegistrationDate,
    COUNT(CASE WHEN r.RentalType = 0 THEN 1 END) AS RentalsPerDay,
    COUNT(CASE WHEN r.RentalType = 1 THEN 1 END) AS RentalsPerView,
    SUM(r.Price) AS TotalSpent,
    CONVERT(date, MAX(r.RentalDate)) AS LastRentalDate, 
    g.Name AS LastRentalGenre,
    COUNT(DISTINCT f.IdMovie) AS FavoriteCount, 
    COUNT(DISTINCT CASE WHEN r.Id IS NOT NULL THEN f.IdMovie END) AS FavoriteRentals, 
    (
        SELECT TOP 1 g.Name
        FROM Rentals r2
        JOIN Movies m2 ON r2.IdMovie = m2.Id
        JOIN Genres g ON m2.IdGenre = g.Id
        WHERE r2.IdUser = u.Id
        GROUP BY g.Name
        ORDER BY COUNT(*) DESC, MIN(r2.RentalDate) ASC
    ) AS TopGenre
FROM AspNetUsers u
LEFT JOIN Rentals r ON u.Id = r.IdUser
LEFT JOIN Movies m ON r.IdMovie = m.Id
LEFT JOIN Genres g ON m.IdGenre = g.Id
LEFT JOIN FavoriteMovies f ON u.Id = f.IdUser
GROUP BY u.Id, u.FirstName, u.LastName, g.Name;