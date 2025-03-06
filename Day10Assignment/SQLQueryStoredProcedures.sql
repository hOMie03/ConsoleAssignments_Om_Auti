use BookStoreDB

-- Q1
CREATE PROCEDURE OrderDetailsByCustID
@CustID int
AS
BEGIN
	SELECT * FROM Orders
	WHERE CustomerID = @CustID;
END
exec OrderDetailsByCustID 10003

-- Q2
CREATE PROCEDURE FilteredRangeBooks
@MinPrice int, @MaxPrice int
AS
BEGIN
	SELECT * FROM Books
	WHERE Price BETWEEN @MinPrice AND @MaxPrice;
END
exec FilteredRangeBooks 100, 400
