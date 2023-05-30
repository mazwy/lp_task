/*
4) Lista użytkowników, 
którzy wypożyczyli pod rząd 2 filmy tego samego reżysera (nie ma znaczenia jakiego)
*/

SELECT 
    u.id, 
    u.FirstName, 
    u.LastName
FROM AspNetUsers u
JOIN rentals r1 ON u.id = r1.IdUser
JOIN movies m1 ON r1.IdMovie = m1.id
JOIN rentals r2 ON u.id = r2.IdUser
JOIN movies m2 ON r2.IdMovie = m2.id
WHERE r2.RentalDate = (
  SELECT MIN(RentalDate)
  FROM rentals
  WHERE IdUser = u.id
  AND RentalDate > r1.ReturnDate
)
AND m1.IdDirector = m2.IdDirector;