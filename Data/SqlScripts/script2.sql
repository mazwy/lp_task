/*
2)	Lista wszystkich niezablokowanych użytkowników, dla każdego z nich podany tytuł trzeciego 
(chronologicznie po dacie wypożyczenia) wypożyczonego filmu.
Jeśli użytkownik nie wypożyczył jeszcze 3 filmów – podajemy „brak danych”.
*/

SELECT 
    u.id,
    u.FirstName, 
    u.LastName, 
    COALESCE(m.title, 'no data') AS third_movie_title
FROM AspNetUsers u
LEFT JOIN (
    SELECT 
        r.IdUser, 
        m.title,
        ROW_NUMBER() OVER (
            PARTITION BY r.IdUser 
            ORDER BY r.RentalDate
        ) AS row_num
    FROM rentals r
    JOIN movies m ON r.IdMovie = m.id
    WHERE r.ReturnDate IS NOT NULL
) m ON u.id = m.IdUser AND m.row_num = 3
WHERE u.LockoutEnabled = 0