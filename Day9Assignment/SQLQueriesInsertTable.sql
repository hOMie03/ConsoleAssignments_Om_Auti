use BookStoreDB

INSERT INTO Authors VALUES (101, 'Stephen King', 'American'), (102, 'Vanishree', 'Indian'),
(103, 'Stephen Hawking', 'UK'), (104, 'J. K. Rowling', 'UK'), (105, 'William Shakespeare', 'UK')

INSERT INTO Books VALUES (1001, 'IT', 101, 300, 1986), (1002, 'SQL Mastery', 102, 400, 2024),
(1003, 'The Universe in a Nutshell', 103, 200, 2001), (1004, 'Harry Potter: The Complete Edition', 104, 699, 2007),
(1005, 'The Tempest', 105, 100, 1593)

INSERT INTO Customers VALUES (10001, 'Om', 'omnomnom@yahoo.com', 9892989291),
(10002, 'Kaps', 'kapil@hotmail.com', 7872777333), (10003, 'Sakthish', 'sakth@gmail.com', 8888899999),
(10004, 'Atharva', 'atharva@onedrive.com', 9922334455), (10005, 'Sumeet', 'sumeet@india.gov.in', 9999999990)

INSERT INTO Orders VALUES (111, 10001, '03-12-2024', 400), (112, 10002, '02-02-2023', 600),
(113, 10003, '07-05-2020', 500), (114, 10004, '11-12-2024', 1398), (115, 10005, '04-10-2022', 200)

INSERT INTO OrderItems VALUES (111, 1002, 1, 400), (112, 1001, 2, 300), (113, 1005, 5, 100),
(114, 1004, 2, 699), (115, 1003, 1, 200)

UPDATE Books
SET Price = Price * 1.10
WHERE Title = 'SQL Mastery'

INSERT INTO Customers VALUES (10006, 'Rahul', 'rahul@neosoft.com', 7734567812)

DELETE Customers FROM Customers
LEFT JOIN Orders
ON Orders.CustomerID = Customers.CustomerID
WHERE Orders.CustomerID IS NULL;

SELECT * FROM Customers;