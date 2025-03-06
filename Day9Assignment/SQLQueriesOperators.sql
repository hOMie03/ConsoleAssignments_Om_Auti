use BookStoreDB

-- Q1
INSERT INTO Books VALUES (1006, 'Golden Book', 102, 5000, 2015)
SELECT * FROM Books WHERE Price > 2000

-- Q2
SELECT Count(BookID) AS TotalBooksAvailable FROM Books

-- Q3
SELECT * FROM Books WHERE PublishedYear BETWEEN 2015 AND 2023

-- Q4
SELECT CustomerID FROM Orders WHERE CustomerID IN (SELECT CustomerID From Orders) -- OR
SELECT CustomerID FROM Orders GROUP BY CustomerID

-- Q5
SELECT * FROM Books WHERE Title LIKE '%SQL%'

-- Q6
SELECT TOP 1 * FROM Books ORDER BY Price DESC

-- Q7
SELECT * FROM Customers WHERE Name LIKE '[A_J]%'

-- Q8
SELECT SUM(TotalAmount) AS TotalRevenue FROM Orders
