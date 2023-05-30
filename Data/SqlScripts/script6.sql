/*
Raport przedstawiający liczbę unikalnych użytkowników systemu w odpowiednim przedziale liczby wypożyczonych filmów – format:
- liczba wypożyczonych filmów -  słownik przedziałów wg których należy pogrupować użytkowników
- liczba unikalnych użytkowników
Liczba filmów	Liczba unikalnych użytkowników
0	12345
1-2	3345
3-5	2789
6-10	1800
11-20	999
21-50	765
50+	345
*/

SELECT 
    RentalRange AS MoviesCount,
    COUNT(DISTINCT IdUser) AS UserCount
FROM (
    SELECT 
        IdUser, 
        COUNT(DISTINCT IdMovie) AS RentalCount,
        CASE 
            WHEN COUNT(DISTINCT IdMovie) = 0 THEN '0'
            WHEN COUNT(DISTINCT IdMovie) BETWEEN 1 AND 2 THEN '1-2'
            WHEN COUNT(DISTINCT IdMovie) BETWEEN 3 AND 5 THEN '3-5'
            WHEN COUNT(DISTINCT IdMovie) BETWEEN 6 AND 10 THEN '6-10'
            WHEN COUNT(DISTINCT IdMovie) BETWEEN 11 AND 20 THEN '11-20'
            WHEN COUNT(DISTINCT IdMovie) BETWEEN 21 AND 50 THEN '21-50'
            ELSE '50+'
        END AS RentalRange
    FROM Rentals
    GROUP BY IdUser
) r
GROUP BY RentalRange;