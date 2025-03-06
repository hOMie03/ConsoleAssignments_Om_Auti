use BookStoreDB

-- Q1
SELECT b.Title, a.Name FROM Books b
JOIN Authors a
ON a.AuthorID = b.AuthorID

-- Q2
SELECT c.CustomerID, c.Name, o.OrderID FROM Customers c
JOIN Orders o
ON o.CustomerID = c.CustomerID

-- Q3
INSERT INTO Books VALUES (1010, 'Noone bought this book', 102, 1000, 1969)
SELECT b.BookID, b.Title FROM Books b
LEFT JOIN OrderItems oi
ON oi.BookID = b.BookID
WHERE oi.BookID IS NULL

-- Q4
SELECT c.CustomerID, COUNT(c.CustomerID) as TotalPurchaseCount FROM Customers c
LEFT JOIN Orders o
ON o.CustomerID = c.CustomerID
GROUP BY c.CustomerID

-- Q5
SELECT b.BookID, b.Title, oi.Quantity FROM Books b
JOIN OrderItems oi
ON oi.BookID = b.BookID

-- Q6
INSERT INTO Customers VALUES (10006, 'Rahul', 'rahul@neosoft.com', 7734567812)
SELECT c.CustomerID, c.Name, o.OrderID FROM Customers c
LEFT JOIN Orders o
ON o.CustomerID = c.CustomerID

-- Q7
INSERT INTO Authors VALUES (111, 'Omie', 'New Zealander')
SELECT a.Name FROM Authors a
LEFT JOIN Books b
ON b.AuthorID = a.AuthorID
WHERE b.AuthorID IS NULL