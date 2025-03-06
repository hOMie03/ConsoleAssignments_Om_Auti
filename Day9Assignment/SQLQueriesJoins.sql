use BookStoreDB

SELECT b.Title, a.Name FROM Books b
JOIN Authors a
ON a.AuthorID = b.AuthorID

SELECT c.CustomerID, c.Name, o.OrderID FROM Customers c
JOIN Orders o
ON o.CustomerID = c.CustomerID

INSERT INTO Books VALUES (1010, 'Noone bought this book', 102, 1000, 1969)

SELECT b.BookID, b.Title FROM Books b
LEFT JOIN OrderItems oi
ON oi.BookID = b.BookID
WHERE oi.BookID IS NULL

SELECT c.CustomerID, COUNT(c.CustomerID) as TotalPurchaseCount FROM Customers c
LEFT JOIN Orders o
ON o.CustomerID = c.CustomerID
GROUP BY c.CustomerID

SELECT b.BookID, b.Title, oi.Quantity FROM Books b
JOIN OrderItems oi
ON oi.BookID = b.BookID

INSERT INTO Customers VALUES (10006, 'Rahul', 'rahul@neosoft.com', 7734567812)
SELECT c.CustomerID, c.Name, o.OrderID FROM Customers c
LEFT JOIN Orders o
ON o.CustomerID = c.CustomerID

INSERT INTO Authors VALUES (111, 'Omie', 'New Zealander')
SELECT a.Name FROM Authors a
LEFT JOIN Books b
ON b.AuthorID = a.AuthorID
WHERE b.AuthorID IS NULL