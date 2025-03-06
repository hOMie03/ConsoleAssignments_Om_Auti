use BookStoreDB

-- Q1
SELECT o.CustomerID, c.Name, o.OrderDate FROM Orders o, Customers c
WHERE c.CustomerID = o.CustomerID
AND o.OrderID = (SELECT TOP 1 OrderID FROM Orders ORDER BY OrderDate ASC)

-- Q2
INSERT INTO Orders VALUES (116, 10003, '2021-08-23', 1000)
SELECT DISTINCT(o.CustomerID), c.Name FROM Orders o, Customers c
WHERE c.CustomerID = o.CustomerID
AND o.CustomerID = (SELECT TOP 1 CustomerID FROM Orders  GROUP BY CustomerID ORDER BY Count(CustomerID) DESC)
SELECT * FROM Orders
SELECT * FROM Customers

-- Q3
SELECT CustomerID, Name FROM Customers
WHERE CustomerID NOT IN (SELECT CustomerID FROM Orders)

-- Q4
SELECT * FROM Books
SELECT BookID, Title FROM Books
WHERE BookID != (SELECT TOP 1 BookID FROM Books ORDER BY Price DESC)

-- Q5
SELECT o.CustomerID, c.Name, o.TotalAmount FROM Orders o, Customers c
WHERE c.CustomerID = o.CustomerID
AND TotalAmount > (SELECT AVG(TotalAmount) FROM Orders)
