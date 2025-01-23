
CREATE PARTITION FUNCTION ProductCategoryPartitionFunction (NVARCHAR(50))
AS RANGE LEFT FOR VALUES ('Stationary', 'Accessories', 'Apparel');
Go
CREATE PARTITION SCHEME ProductCategoryPartitionScheme
AS PARTITION ProductCategoryPartitionFunction
ALL TO ([PRIMARY]);
Go
CREATE TABLE [dbo].[Product] (
    [ID]              INT IDENTITY(1,1) NOT NULL,
    [Name]            NVARCHAR (MAX)  NOT NULL,
    [Category]        NVARCHAR (50)  NOT NULL,
    [Price]           DECIMAL (18, 2) NOT NULL,
    [ManufactureDate] DATETIME2 (7)   NOT NULL,
    [Active]          BIT             NOT NULL,
    CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED ([ID] ASC, [Category])
)ON ProductCategoryPartitionScheme([Category]);

CREATE INDEX index1 ON [dbo].[Product] ([ID]);

Go

SET IDENTITY_INSERT [dbo].[Product] ON;  
GO  

INSERT INTO [dbo].[Product] ([ID], [Name], [Category], [Price], [ManufactureDate], [Active])
VALUES 
(1, 'Folder', 'Stationary', 11, '2022-05-01', 1), (2, 'Sticky Notes', 'Stationary', 22, '2023-01-01', 1), (3, 'Notebook', 'Stationary', 14, '2024-01-01', 1),
(4, 'Ruler', 'Stationary', 2, '2021-01-01', 1), (5, 'Binder Clips', 'Stationary', 15, '2021-11-01', 1), (6, 'Color Pencil', 'Stationary', 8, '2022-11-08', 1),
(7, 'Paper Cutter', 'Stationary', 8, '2024-01-01', 1), (8, 'Eraser', 'Stationary', 12, '2021-12-01', 1), (9, 'Paper', 'Stationary', 13, '2023-12-01', 1),

(10, 'Cap', 'Accessories', 8, '2024-01-01', 1), (11, 'Scarf', 'Accessories', 12, '2021-12-01', 1), (12, 'Gloves', 'Accessories', 13, '2023-12-01', 1),
(13, 'Jewelry', 'Accessories', 8, '2024-01-01', 1), (14, 'Wristwatch', 'Accessories', 12, '2021-12-01', 1), (15, 'Sunglasses', 'Accessories', 13, '2023-12-01', 1),

(16, 'Jacket', 'Apparel', 18, '2024-12-03', 1), (17, 'Pants', 'Apparel', 20, '2023-11-07', 1), (18, 'Sweater', 'Apparel', 16, '2023-11-01', 1),
(19, 'Socks', 'Apparel', 28, '2024-11-01', 1), (20, 'Hat', 'Apparel', 12, '2021-11-05', 1), (21, 'Dress', 'Apparel', 10, '2023-12-08', 1);

SET IDENTITY_INSERT [dbo].[Product] OFF;  
GO  

CREATE PARTITION FUNCTION UserAccountActivePartitionFunction (BIT)
AS RANGE LEFT FOR VALUES (0, 1);
Go
CREATE PARTITION SCHEME UserAccountActivePartitionScheme
AS PARTITION UserAccountActivePartitionFunction
ALL TO ([PRIMARY]);
Go
CREATE TABLE [dbo].[UserAccount] (
    [ID]          INT IDENTITY(1,1) NOT NULL,
    [FirstName]   NVARCHAR (MAX) NOT NULL,
    [LastName]    NVARCHAR (MAX) NOT NULL,
    [DateOfBirth] DATETIME2 (7)  NOT NULL,
    [Active]      BIT            NOT NULL,
    CONSTRAINT [PK_UserAccount] PRIMARY KEY CLUSTERED ([ID] ASC, [Active])
)ON UserAccountActivePartitionScheme([Active]);

CREATE INDEX index2 ON [dbo].[UserAccount] ([ID]);
Go

SET IDENTITY_INSERT [dbo].[UserAccount] ON;  
GO  

INSERT INTO [dbo].[UserAccount] ([ID], [FirstName], [LastName], [DateOfBirth], [Active])
VALUES 
(1, 'Mikko', 'Virtanen', '1988-04-07', 1), (2, 'Anna', 'Korhonen', '1987-11-09', 1), ('3', 'Jussi', 'Niemi', '1973-06-12', 1),
(4, 'Sari', 'Lahtinen', '1973-06-08', 0), (5, 'Petri', 'Salminen', '1996-07-09', 0), ('6', 'Emma', 'Rautio', '1972-01-11', 0),
(7, 'Tuomas', 'Lehtonen', '1977-09-12', 1), (8, 'Kaisa', 'Heikkinen', '1996-03-11', 1), ('9', 'Markus', 'Järvinen', '1977-08-11', 1),
(10, 'Laura', 'Hämäläinen', '1979-02-11', 0), (11, 'Janne', 'Koskinen', '1999-07-06', 0), ('12', 'Päivi', 'Mäkinen', '1973-11-12', 0),
(13, 'Eero', 'Tuominen', '1976-02-09', 1), (14, 'Sanna', 'Rinne', '1987-06-11', 1), ('15', 'Olli', 'Kallio', '1973-11-09', 1),
(16, 'Veera', 'Peltola', '1993-04-03', 0), (17, 'Antti', 'Savolainen', '1983-10-04', 0), ('18', 'Riikka', 'Salo', '1982-02-11', 0),
(19, 'Matti', 'Alanko', '1995-06-01', 1), (20, 'Inka', 'Vainio', '1991-12-01', 1);	

SET IDENTITY_INSERT [dbo].[UserAccount] OFF;  
GO  


CREATE PARTITION FUNCTION OrderDatePartitionFunction (DATETIME)
AS RANGE LEFT FOR VALUES ('2022-12-31', '2023-12-31', '2024-12-31');
Go
CREATE PARTITION SCHEME OrderDatePartitionScheme
AS PARTITION OrderDatePartitionFunction
ALL TO ([PRIMARY]);
Go
CREATE TABLE [dbo].[Order] (
    [ID]              INT IDENTITY(1,1) NOT NULL,
    [OrderDate]       DATETIME  NOT NULL,
    [UserID]          INT  NOT NULL,
    [DeliveryAddress] NVARCHAR (255) NOT NULL,
    CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED ([ID] ASC,  [OrderDate]),
)ON OrderDatePartitionScheme([OrderDate]);

CREATE INDEX index3 ON [dbo].[Order] ([ID]);

Go

SET IDENTITY_INSERT [dbo].[Order] ON;  
GO  

INSERT INTO [dbo].[Order] ([ID], [OrderDate], [UserID], [DeliveryAddress])
VALUES 
(1, '2022-03-16', 1 , ''), (2, '2022-01-08', 1 , ''), (3, '2022-07-22', 1 , ''),
(4, '2022-02-04', 1 , ''), (5, '2022-11-12', 1 , ''), (6, '2022-02-12', 1 , ''),
(7, '2022-01-20', 1 , ''), (8, '2022-09-15', 1 , ''), (9, '2022-05-14', 1 , ''), (10, '2022-04-01', 1 , ''),

(11, '2023-04-17', 1 , ''), (12, '2023-04-02', 1 , ''), (13, '2023-04-02', 1 , ''),
(14, '2023-05-23', 1 , ''), (15, '2023-07-12', 1 , ''), (16, '2023-08-17', 1 , ''),
(17, '2023-06-11', 1 , ''), (18, '2023-09-23', 1 , ''), (19, '2023-11-22', 1 , ''), (20, '2023-09-21', 1 , ''),

(21, '2024-03-07', 1 , ''), (22, '2024-01-07', 1 , ''), (23, '2024-11-21', 1 , ''),
(24, '2024-07-12', 1 , ''), (25, '2024-03-11', 1 , ''), (26, '2024-12-07', 1 , ''),
(27, '2024-09-21', 1 , ''), (28, '2024-09-21', 1 , ''), (29, '2024-07-11', 1 , ''), (30, '2024-05-15', 1 , '');



GO

SET IDENTITY_INSERT [dbo].[Order] OFF;  
GO  


CREATE NONCLUSTERED INDEX [IX_Order_UserID]
    ON [dbo].[Order]([UserID] ASC);


CREATE TABLE [dbo].[OrderLine] (
    [ID]        INT IDENTITY(1,1)  NOT NULL,
    [OrderID]   INT   NOT NULL,
    [ProductID] INT   NOT NULL,
    [Quantity]  DECIMAL (18, 2) NOT NULL,
    CONSTRAINT [PK_OrderLine] PRIMARY KEY CLUSTERED ([ID] ASC),
);

CREATE INDEX index4 ON [dbo].[OrderLine] ([ID]);

Go

SET IDENTITY_INSERT [dbo].[OrderLine] ON;  
GO  


INSERT INTO [dbo].[OrderLine] ([ID], [OrderID], [ProductID], [Quantity])
VALUES 
(1, 1, 1, 10), 
(2, 1, 2, 3), 
(3, 1, 3, 7), 
(4, 1, 4, 8), 
(5, 1, 5, 1),
(6, 2, 1, 8), 
(7, 2, 2, 7), 
(8, 2, 3, 4), 
(9, 2, 4, 18), 
(10, 2, 5, 11),
(11, 3, 1, 10), 
(12, 3, 2, 3), 
(13, 3, 3, 7), 
(14, 3, 4, 8), 
(15, 3, 5, 1),
(16, 4, 1, 8), 
(17, 4, 2, 7), 
(18, 4, 3, 4), 
(19, 4, 4, 18), 
(20, 4, 5, 11);

GO

SET IDENTITY_INSERT [dbo].[OrderLine] OFF;  
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
    [ID]           INT IDENTITY(1,1)  NOT NULL,
    [ProductID]    INT   NOT NULL,
    [AvailableQty] DECIMAL (18, 2) NOT NULL,
    CONSTRAINT [PK_WarehouseStock] PRIMARY KEY CLUSTERED ([ID] ASC, [AvailableQty]),
) ON WarehouseStockAvailableQtyPartitionScheme([AvailableQty]);

CREATE INDEX index2 ON [dbo].[WarehouseStock] ([ID]);

Go

SET IDENTITY_INSERT [dbo].[WarehouseStock] ON;  
GO  

INSERT INTO [dbo].[WarehouseStock] ([ID], [ProductID], [AvailableQty])
VALUES 
(1, 1, 10), 
(2, 2, 12), 
(3, 3, 110), 
(4, 4, 95), 
(5, 5, 40),
(6, 6, 100), 
(7, 7, 34), 
(8, 8, 10), 
(9, 9, 45), 
(10, 10, 80),
(11, 11, 50), 
(12, 12, 22), 
(13, 13, 10), 
(14, 14, 15), 
(15, 15, 110),
(16, 16, 60), 
(17, 17, 33), 
(18, 18, 10), 
(19, 19, 10), 
(20, 20, 210);

GO

SET IDENTITY_INSERT [dbo].[WarehouseStock] OFF;  
GO  

CREATE NONCLUSTERED INDEX [IX_WarehouseStock_ProductID]
    ON [dbo].[WarehouseStock]([ProductID] ASC);


