use BookStoreDB
INSERT INTO Books VALUES (1006, 'Golden Book', 102, 5000, 2015)
SELECT * FROM Books WHERE Price > 2000

SELECT Count(BookID) AS TotalBooksAvailable FROM Books

SELECT * FROM Books WHERE PublishedYear BETWEEN 2015 AND 2023

SELECT CustomerID FROM Orders WHERE CustomerID IN (SELECT CustomerID From Orders)
SELECT CustomerID FROM Orders GROUP BY CustomerID

SELECT * FROM Books WHERE Title LIKE '%SQL%'

SELECT TOP 1 * FROM Books ORDER BY Price DESC

SELECT * FROM Customers WHERE Name LIKE '[A_J]%'

SELECT SUM(TotalAmount) AS TotalRevenue FROM Orders

