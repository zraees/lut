CREATE DATABASE [sqlserverUSA]
GO

USE [sqlserverUSA];
GO

CREATE TABLE Product (
    Id INT NOT NULL IDENTITY,
    Name TEXT NOT NULL,
    Description TEXT NOT NULL,
    PRIMARY KEY (Id)
);
GO

INSERT INTO [product] (Name, Description)
VALUES 
('T-Shirt Blue', 'Its blue'),
('T-Shirt Black', 'Its black'); 
GO