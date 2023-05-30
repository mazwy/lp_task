/*
Wykonanie listy rankingowej najbardziej aktywnych użytkowników w poprzednim miesiącu, 
czyli takich którzy wypożyczyli przynajmniej 12 filmów. 
 O pozycji w rankingu powinna decydować (dane liczone tylko dla wypożyczeni z poprzedniego miesiąca):
- liczba wypożyczonych filmów (im więcej tym lepiej)
- maksymalna liczba filmów wypożyczonych jednego dnia (im więcej tym lepiej)
- data pierwszego wypożyczenia w miesiącu (im wcześniej tym lepiej)
*/

SELECT 
    u.Id, 
    u.FirstName, 
    u.LastName, 
    COUNT(*) AS RentalCount, 
    MAX(drc.DailyRentalCount) AS MaxDailyRentalCount, 
    MIN(r.RentalDate) AS FirstRentalDate
FROM AspNetUsers u
JOIN Rentals r ON u.Id = r.IdUser
JOIN (
    SELECT 
        IdUser, 
        RentalDate, 
        COUNT(*) AS DailyRentalCount
    FROM Rentals
    WHERE RentalDate >= DATEADD(month, DATEDIFF(month, 0, GETDATE()) - 1, 0)
    AND RentalDate < DATEADD(month, DATEDIFF(month, 0, GETDATE()), 0)
    GROUP BY IdUser, RentalDate
) drc ON r.IdUser = drc.IdUser AND r.RentalDate = drc.RentalDate
WHERE r.RentalDate >= DATEADD(month, DATEDIFF(month, 0, GETDATE()) - 1, 0)
AND r.RentalDate < DATEADD(month, DATEDIFF(month, 0, GETDATE()), 0)
GROUP BY u.Id, u.FirstName, u.LastName
HAVING COUNT(*) >= 12
ORDER BY RentalCount DESC, MaxDailyRentalCount DESC, FirstRentalDate ASC;