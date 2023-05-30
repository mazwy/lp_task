/*
3) Lista użytkowników, którzy przynajmniej raz po wypożyczeniu filmu z gatunku „kryminał” 
przy następnym wypożyczeniu wybrali film z gatunku „komedia”
*/

SELECT 
    u.Id, 
    u.FirstName, 
    u.LastName
FROM AspNetUsers u
JOIN (
    SELECT 
        IdUser, 
        IdMovie, 
        RentalDate, 
        ROW_NUMBER() OVER (
            PARTITION BY IdUser 
            ORDER BY RentalDate
        ) AS RowNum
    FROM Rentals
    JOIN Movies ON Rentals.IdMovie = Movies.Id
    JOIN Genres ON Movies.IdGenre = Genres.Id AND Genres.Name = 'Crime'
) r1 ON u.Id = r1.IdUser
JOIN (
    SELECT IdUser, IdMovie, RentalDate, ROW_NUMBER() OVER (PARTITION BY IdUser ORDER BY RentalDate) AS RowNum
    FROM Rentals
    JOIN Movies ON Rentals.IdMovie = Movies.Id
    JOIN Genres ON Movies.IdGenre = Genres.Id AND Genres.Name = 'Comedy'
) r2 ON u.Id = r2.IdUser AND r2.RowNum = r1.RowNum + 1 AND r2.RentalDate > r1.RentalDate
WHERE u.LockoutEnabled = 0;