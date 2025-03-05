CREATE DATABASE BookStoreDB;
use BookStoreDB
CREATE TABLE Authors (
	AuthorID int PRIMARY KEY,
	Name varchar(50) NOT NULL,
	Country varchar(50)
);

CREATE TABLE Books (
	BookID int PRIMARY KEY,
	Title varchar(100) NOT NULL,
	AuthorID int,
	Price decimal NOT NULL,
	PublishedYear int
);
ALTER TABLE Books
ADD CONSTRAINT FK_Books_BookID
FOREIGN KEY (AuthorID) REFERENCES Authors(AuthorID)

CREATE TABLE Customers (
	CustomerID int PRIMARY KEY,
	Name varchar(50) NOT NULL,
	Email varchar(100),
	PhoneNumber bigint unique
);

CREATE TABLE Orders (
	OrderID int PRIMARY KEY,
	CustomerID int,
	OrderDate date NOT NULL,
	TotalAmount decimal
);
ALTER TABLE Orders
ADD CONSTRAINT FK_Orders_CustomerID
FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID)

CREATE TABLE OrderItems (
	OrderItemID int identity,
	OrderID int,
	BookID int,
	Quantity int,
	SubTotal int
);
ALTER TABLE OrderItems
ADD CONSTRAINT FK_OrderItems_OrderID
FOREIGN KEY (OrderID) REFERENCES Orders(OrderID)
ALTER TABLE OrderItems
ADD CONSTRAINT FK_OrderItems_BookID
FOREIGN KEY (BookID) REFERENCES Books(BookID)
