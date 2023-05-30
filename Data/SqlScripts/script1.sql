/*
1)	Lista użytkowników, których ostatni wypożyczony film był z gatunku „komedia”. 
Przy każdym użytkowniku należy podać tytuł tego ostatnio wypożyczonego filmu.
*/

SELECT 
    u.Id, 
    u.FirstName, 
    u.LastName, 
    m.Title AS LastRentedMovie 
FROM AspNetUsers u 
JOIN Rentals r ON u.Id = r.IdUser 
JOIN Movies m ON r.IdMovie = m.Id 
JOIN Genres g ON m.IdGenre = g.Id 
    AND g.Name = 'Comedy'
WHERE r.RentalDate = (
    SELECT MAX(RentalDate) 
    FROM Rentals 
    WHERE IdUser = u.Id
);