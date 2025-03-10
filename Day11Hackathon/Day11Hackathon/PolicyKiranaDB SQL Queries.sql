CREATE DATABASE PolicyKiranaDB

use PolicyKiranaDB

CREATE TABLE UserDetails (
	UserID int IDENTITY PRIMARY KEY,
	Username varchar(50) NOT NULL,
	UserPassword varchar(50) NOT NULL
)
CREATE TABLE PolicyDetails (
	PolicyID bigint PRIMARY KEY,
	UserID int,
	PolicyHolderName varchar(100) NOT NULL,
	PolicyType int NOT NULL,
	StartDate date NOT NULL,
	EndDate date NOT NULL
)

ALTER TABLE PolicyDetails
ADD CONSTRAINT FK_PolicyDetails_UserID
FOREIGN KEY (UserID) REFERENCES UserDetails(UserID)

INSERT INTO UserDetails VALUES ('admin', 'admin')
SELECT * FROM UserDetails;

DELETE FROM UserDetails WHERE UserID = 2

INSERT INTO PolicyDetails VALUES (1110032025, 1, 'admin', 1, '2025/03/10', '2030/03/10')
SELECT * FROM PolicyDetails
SELECT * FROM PolicyDetails WHERE UserID = (SELECT UserID FROM UserDetails WHERE Username = 'admin')

CREATE TRIGGER tk_EndDateWrong ON PolicyDetails FOR UPDATE
AS
BEGIN
	IF EXISTS (
        SELECT 1 FROM inserted WHERE EndDate <= StartDate
    )
    BEGIN
        PRINT 'Error: EndDate must be greater than StartDate.';
        ROLLBACK TRANSACTION;
    END
END;
