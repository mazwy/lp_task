/*
5)	Lista użytkowników, w następnych kolumnach tytuły 3 filmów (proszę sobie dowolnie wybrać), 
dla każdego użytkownika wyliczone ile razy wypożyczył dany film:
*/

SELECT 
    u.Id, 
    u.FirstName,
     u.LastName, 
    SUM(CASE WHEN m.Title = 'Jurassic Park' THEN 1 ELSE 0 END) AS 'Jurassic Park',
    SUM(CASE WHEN m.Title = 'The Dark Knight' THEN 1 ELSE 0 END) AS 'The Dark Knight',
    SUM(CASE WHEN m.Title = 'Pulp Fiction' THEN 1 ELSE 0 END) AS 'Pulp Fiction'
FROM AspNetUsers u
LEFT JOIN Rentals r ON u.Id = r.IdUser
LEFT JOIN Movies m ON r.IdMovie = m.Id
GROUP BY u.Id, u.FirstName, u.LastName;

