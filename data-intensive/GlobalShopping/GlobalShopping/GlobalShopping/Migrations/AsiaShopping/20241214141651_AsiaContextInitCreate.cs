using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GlobalShopping.Migrations.AsiaShopping
{
    /// <inheritdoc />
    public partial class AsiaContextInitCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"


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
(1, 'Pencil', 'Stationary', 11, '2022-05-01', 1), (2, 'Marker', 'Stationary', 22, '2023-01-01', 1), (3, 'Crayons', 'Stationary', 14, '2024-01-01', 1),
(4, 'Pin', 'Stationary', 2, '2021-01-01', 1), (5, 'Pen', 'Stationary', 15, '2021-11-01', 1), (6, 'Cartridge', 'Stationary', 8, '2022-11-08', 1),
(7, 'Paper', 'Stationary', 8, '2024-01-01', 1), (8, 'Glue', 'Stationary', 12, '2021-12-01', 1), (9, 'Papers', 'Stationary', 13, '2023-12-01', 1),

(10, 'Shoe', 'Accessories', 8, '2024-01-01', 1), (11, 'Case', 'Accessories', 12, '2021-12-01', 1), (12, 'Holders', 'Accessories', 13, '2023-12-01', 1),
(13, 'Socks', 'Accessories', 8, '2024-01-01', 1), (14, 'Key chains', 'Accessories', 12, '2021-12-01', 1), (15, 'Reflectors', 'Accessories', 13, '2023-12-01', 1),

(16, 'Jeans', 'Apparel', 18, '2024-12-03', 1), (17, 'Pant', 'Apparel', 20, '2023-11-07', 1), (18, 'Shorts', 'Apparel', 16, '2023-11-01', 1),
(19, 'Shirts', 'Apparel', 28, '2024-11-01', 1), (20, 'Trouser', 'Apparel', 12, '2021-11-05', 1), (21, 'Rain Coats', 'Apparel', 10, '2023-12-08', 1);

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
(1, 'Adeline', 'Yen', '1985-03-01', 1), (2, 'Coral', 'Wong', '1993-01-01', 1), ('3', 'June', 'Kuramoto', '1971-05-11', 1),
(4, 'Ali', 'Wong', '1973-02-01', 0), (5, 'Elaine', 'Chao', '1992-02-01', 0), ('6', 'Kimko', 'Hanh', '1972-03-01', 0),
(7, 'Amy', 'Tan', '1974-12-01', 1), (8, 'Eva', 'Chen', '1991-03-01', 1), ('9', 'Yifei', 'Liu', '1973-12-01', 1),
(10, 'Anna', 'Wong', '1975-05-01', 0), (11, 'Helen', 'Zia', '1998-05-01', 0), ('12', 'Marie', 'Kondo', '1971-10-11', 0),
(13, 'Celeste', 'Ng', '1986-02-11', 1), (14, 'Jade', 'Snow', '1985-06-01', 1), ('15', 'Fong', 'Eu', '1970-11-05', 1),
(16, 'Chien', 'Wu', '1993-04-03', 0), (17, 'Jenny', 'Han', '1982-12-01', 0), ('18', 'Margaret', 'Cho', '1972-12-01', 0),
(19, 'Chloe', 'Kim', '1995-06-01', 1), (20, 'Keiko', 'Agena', '1990-11-01', 1);	

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
(1, '2022-01-15', 1 , ''), (2, '2022-02-20', 1 , ''), (3, '2022-03-30', 1 , ''),
(4, '2022-04-05', 1 , ''), (5, '2022-05-10', 1 , ''), (6, '2022-06-15', 1 , ''),
(7, '2022-07-20', 1 , ''), (8, '2022-08-25', 1 , ''), (9, '2022-09-30', 1 , ''), (10, '2022-10-31', 1 , ''),

(11, '2023-01-15', 1 , ''), (12, '2023-02-20', 1 , ''), (13, '2023-03-30', 1 , ''),
(14, '2023-04-05', 1 , ''), (15, '2023-05-10', 1 , ''), (16, '2023-06-15', 1 , ''),
(17, '2023-07-20', 1 , ''), (18, '2023-08-25', 1 , ''), (19, '2023-09-30', 1 , ''), (20, '2023-10-31', 1 , ''),

(21, '2024-01-15', 1 , ''), (22, '2024-02-20', 1 , ''), (23, '2024-03-30', 1 , ''),
(24, '2024-04-05', 1 , ''), (25, '2024-05-10', 1 , ''), (26, '2024-06-15', 1 , ''),
(27, '2024-07-20', 1 , ''), (28, '2024-08-25', 1 , ''), (29, '2024-09-30', 1 , ''), (30, '2024-10-31', 1 , '');



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



            ");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderLine");

            migrationBuilder.DropTable(
                name: "WarehouseStock");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "UserAccount");
        }
    }
}
