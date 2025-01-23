
CREATE PARTITION FUNCTION ProductCategoryPartitionFunction (NVARCHAR(50))
AS RANGE LEFT FOR VALUES ('Stationary', 'Accessories', 'Apparel');
Go
CREATE PARTITION SCHEME ProductCategoryPartitionScheme
AS PARTITION ProductCategoryPartitionFunction
ALL TO ([PRIMARY]);
Go
CREATE TABLE [dbo].[Product] (
    [ID]              VARCHAR (100)   NOT NULL,
    [Name]            NVARCHAR (MAX)  NOT NULL,
    [Category]        NVARCHAR (50)  NOT NULL,
    [Price]           DECIMAL (18, 2) NOT NULL,
    [ManufactureDate] DATETIME2 (7)   NOT NULL,
    [Active]          BIT             NOT NULL,
    CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED ([ID] ASC, [Category])
)ON ProductCategoryPartitionScheme([Category]);


Go
INSERT INTO [dbo].[Product] ([ID], [Name], [Category], [Price], [ManufactureDate], [Active])
VALUES 
('1', 'Pencil', 'Stationary', 11, '2022-05-01', 1), ('2', 'Marker', 'Stationary', 22, '2023-01-01', 1), ('3', 'Notebook', 'Stationary', 14, '2024-01-01', 1),
('4', 'Pin', 'Stationary', 2, '2021-01-01', 1), ('5', 'Pen', 'Stationary', 15, '2021-11-01', 1), ('6', 'Colorbox', 'Stationary', 8, '2022-11-08', 1),
('7', 'Paper', 'Stationary', 8, '2024-01-01', 1), ('8', 'Paint', 'Stationary', 12, '2021-12-01', 1), ('9', 'Bag', 'Stationary', 13, '2023-12-01', 1),

('10', 'Shoe', 'Accessories', 8, '2024-01-01', 1), ('11', 'Watch', 'Accessories', 12, '2021-12-01', 1), ('12', 'Ring', 'Accessories', 13, '2023-12-01', 1),
('13', 'Socks', 'Accessories', 8, '2024-01-01', 1), ('14', 'Neclace', 'Accessories', 12, '2021-12-01', 1), ('15', 'Ear Ring', 'Accessories', 13, '2023-12-01', 1),

('16', 'Jeans', 'Apparel', 18, '2024-12-03', 1), ('17', 'Pant', 'Apparel', 20, '2023-11-07', 1), ('18', 'Shorts', 'Apparel', 16, '2023-11-01', 1),
('19', 'Shirts', 'Apparel', 28, '2024-11-01', 1), ('20', 'Trouser', 'Apparel', 12, '2021-11-05', 1), ('21', 'Rain Coats', 'Apparel', 10, '2023-12-08', 1);

CREATE PARTITION FUNCTION UserAccountActivePartitionFunction (BIT)
AS RANGE LEFT FOR VALUES (0, 1);
Go
CREATE PARTITION SCHEME UserAccountActivePartitionScheme
AS PARTITION UserAccountActivePartitionFunction
ALL TO ([PRIMARY]);
Go
CREATE TABLE [dbo].[UserAccount] (
    [ID]          VARCHAR (100)  NOT NULL,
    [FirstName]   NVARCHAR (MAX) NOT NULL,
    [LastName]    NVARCHAR (MAX) NOT NULL,
    [DateOfBirth] DATETIME2 (7)  NOT NULL,
    [Active]      BIT            NOT NULL,
    CONSTRAINT [PK_UserAccount] PRIMARY KEY CLUSTERED ([ID] ASC, [Active])
)ON UserAccountActivePartitionScheme([Active]);

Go
INSERT INTO [dbo].[UserAccount] ([ID], [FirstName], [LastName], [DateOfBirth], [Active])
VALUES 
('1', 'Joshua', 'Michelle', '1985-03-01', 1), ('2', 'William', 'Barbara', '1993-01-01', 1), ('3', 'Matthew', 'Sandra', '1971-05-11', 1),
('4', 'Paul', 'Donna', '1973-02-01', 0), ('5', 'Richard', 'Susan', '1992-02-01', 0), ('6', 'Anthony', 'Betty', '1972-03-01', 0),
('7', 'James', 'Mary', '1974-12-01', 1), ('8', 'Joseph', 'Jessica', '1991-03-01', 1), ('9', 'Mark', 'Ashley', '1973-12-01', 1),
('10', 'Michael', 'Patricia', '1975-05-01', 0), ('11', 'Thomas', 'Karen', '1998-05-01', 0), ('12', 'Donald', 'Emily', '1971-10-11', 0),
('13', 'Robert', 'Jennifer', '1986-02-11', 1), ('14', 'Christopher', 'Sarah', '1985-06-01', 1), ('15', 'Steven', 'Kimberly', '1970-11-05', 1),
('16', 'John', 'Linda', '1993-04-03', 0), ('17', 'Charles', 'Lisa', '1982-12-01', 0), ('18', 'Andrew', 'Margaret', '1972-12-01', 0),
('19', 'David', 'Elizabeth', '1995-06-01', 1), ('20', 'Daniel', 'Nancy', '1990-11-01', 1);	


CREATE PARTITION FUNCTION OrderDatePartitionFunction (DATETIME)
AS RANGE LEFT FOR VALUES ('2022-12-31', '2023-12-31', '2024-12-31');
Go
CREATE PARTITION SCHEME OrderDatePartitionScheme
AS PARTITION OrderDatePartitionFunction
ALL TO ([PRIMARY]);
Go
CREATE TABLE [dbo].[Order] (
    [ID]              VARCHAR (100)  NOT NULL,
    [OrderDate]       DATETIME  NOT NULL,
    [UserID]          VARCHAR (100)  NOT NULL,
    [DeliveryAddress] NVARCHAR (255) NOT NULL,
    CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED ([ID] ASC,  [OrderDate]),
)ON OrderDatePartitionScheme([OrderDate]);


Go
INSERT INTO [dbo].[Order] ([ID], [OrderDate], [UserID], [DeliveryAddress])
VALUES 
('ID1', '2022-01-15', '1' , ''), ('ID2', '2022-02-20', '1' , ''), ('ID3', '2022-03-30', '1' , ''),
('ID4', '2022-04-05', '1' , ''), ('ID5', '2022-05-10', '1' , ''), ('ID6', '2022-06-15', '1' , ''),
('ID7', '2022-07-20', '1' , ''), ('ID8', '2022-08-25', '1' , ''), ('ID9', '2022-09-30', '1' , ''), ('ID10', '2022-10-31', '1' , ''),

('ID11', '2023-01-15', '1' , ''), ('ID12', '2023-02-20', '1' , ''), ('ID13', '2023-03-30', '1' , ''),
('ID14', '2023-04-05', '1' , ''), ('ID15', '2023-05-10', '1' , ''), ('ID16', '2023-06-15', '1' , ''),
('ID17', '2023-07-20', '1' , ''), ('ID18', '2023-08-25', '1' , ''), ('ID19', '2023-09-30', '1' , ''), ('ID20', '2023-10-31', '1' , ''),

('ID21', '2024-01-15', '1' , ''), ('ID22', '2024-02-20', '1' , ''), ('ID23', '2024-03-30', '1' , ''),
('ID24', '2024-04-05', '1' , ''), ('ID25', '2024-05-10', '1' , ''), ('ID26', '2024-06-15', '1' , ''),
('ID27', '2024-07-20', '1' , ''), ('ID28', '2024-08-25', '1' , ''), ('ID29', '2024-09-30', '1' , ''), ('ID30', '2024-10-31', '1' , '');



GO
CREATE NONCLUSTERED INDEX [IX_Order_UserID]
    ON [dbo].[Order]([UserID] ASC);


CREATE TABLE [dbo].[OrderLine] (
    [ID]        VARCHAR (100)   NOT NULL,
    [OrderID]   VARCHAR (100)   NOT NULL,
    [ProductID] VARCHAR (100)   NOT NULL,
    [Quantity]  DECIMAL (18, 2) NOT NULL,
    CONSTRAINT [PK_OrderLine] PRIMARY KEY CLUSTERED ([ID] ASC),
);

Go
INSERT INTO [dbo].[OrderLine] ([ID], [OrderID], [ProductID], [Quantity])
VALUES 
('1', 'ID1', '1', 10), ('2', 'ID1', '2', 3), ('3', 'ID1', '3', 7), ('4', 'ID1', '4', 8), ('5', 'ID1', '5', 1),
('6', 'ID2', '1', 8), ('7', 'ID2', '2', 7), ('8', 'ID2', '3', 4), ('9', 'ID2', '4', 18), ('10', 'ID2', '5', 11),
('11', 'ID3', '1', 10), ('12', 'ID3', '2', 3), ('13', 'ID3', '3', 7), ('14', 'ID3', '4', 8), ('15', 'ID3', '5', 1),
('16', 'ID4', '1', 8), ('17', 'ID4', '2', 7), ('18', 'ID4', '3', 4), ('19', 'ID4', '4', 18), ('20', 'ID4', '5', 11);

GO
CREATE NONCLUSTERED INDEX [IX_OrderLine_OrderID]
    ON [dbo].[OrderLine]([OrderID] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_OrderLine_ProductID]
    ON [dbo].[OrderLine]([ProductID] ASC);

CREATE PARTITION FUNCTION WarehouseStockAvailableQtyPartitionFunction (DECIMAL (18, 2))
AS RANGE LEFT FOR VALUES (0, 1000);
Go
CREATE PARTITION SCHEME WarehouseStockAvailableQtyPartitionScheme
AS PARTITION WarehouseStockAvailableQtyPartitionFunction
ALL TO ([PRIMARY]);
Go

CREATE TABLE [dbo].[WarehouseStock] (
    [ID]           VARCHAR (100)   NOT NULL,
    [ProductID]    VARCHAR (100)   NOT NULL,
    [AvailableQty] DECIMAL (18, 2) NOT NULL,
    CONSTRAINT [PK_WarehouseStock] PRIMARY KEY CLUSTERED ([ID] ASC, [AvailableQty]),
) ON WarehouseStockAvailableQtyPartitionScheme([AvailableQty]);

Go
INSERT INTO [dbo].[WarehouseStock] ([ID], [ProductID], [AvailableQty])
VALUES 
('1', '1', 10), ('2', '2', 12), ('3', '3', 110), ('4', '4', 95), ('5', '5', 40),
('6', '6', 100), ('7', '7', 34), ('8', '8', 10), ('9', '9', 45), ('10', '10', 80),
('11', '11', 50), ('12', '12', 22), ('13', '13', 10), ('14', '14', 15), ('15', '15', 110),
('16', '16', 60), ('17', '17', 33), ('18', '18', 10), ('19', '19', 10), ('20', '20', 210);

GO
CREATE NONCLUSTERED INDEX [IX_WarehouseStock_ProductID]
    ON [dbo].[WarehouseStock]([ProductID] ASC);


