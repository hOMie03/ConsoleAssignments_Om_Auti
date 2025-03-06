use BookStoreDB

-- Q1 Create a view named LatestAvailableBooks which shows only books which are published after 2024
CREATE VIEW LatestAvailableBooks
AS
SELECT * FROM Books WHERE PublishedYear > 2023;

SELECT * FROM LatestAvailableBooks