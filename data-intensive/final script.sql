USE GlobalShoping
Go
/*Product.Category = “Electronics” */
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

/*UserAccount.Active */
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

/*Order.OrderDate */
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
    --CONSTRAINT [FK_Order_UserAccount_UserID] FOREIGN KEY ([UserID]) REFERENCES [dbo].[UserAccount] ([ID]) ON DELETE CASCADE
)ON OrderDatePartitionScheme([OrderDate]);


GO
CREATE NONCLUSTERED INDEX [IX_Order_UserID]
    ON [dbo].[Order]([UserID] ASC);


CREATE TABLE [dbo].[OrderLine] (
    [ID]        VARCHAR (100)   NOT NULL,
    [OrderID]   VARCHAR (100)   NOT NULL,
    [ProductID] VARCHAR (100)   NOT NULL,
    [Quantity]  DECIMAL (18, 2) NOT NULL,
    CONSTRAINT [PK_OrderLine] PRIMARY KEY CLUSTERED ([ID] ASC),
    --CONSTRAINT [FK_OrderLine_Order_OrderID] FOREIGN KEY ([OrderID]) REFERENCES [dbo].[Order] ([ID]) ON DELETE CASCADE,
    --CONSTRAINT [FK_OrderLine_Product_ProductID] FOREIGN KEY ([ProductID]) REFERENCES [dbo].[Product] ([ID]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_OrderLine_OrderID]
    ON [dbo].[OrderLine]([OrderID] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_OrderLine_ProductID]
    ON [dbo].[OrderLine]([ProductID] ASC);

/*WarehouseStock.AvailableQty */
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
    --CONSTRAINT [FK_WarehouseStock_Product_ProductID] FOREIGN KEY ([ProductID]) REFERENCES [dbo].[Product] ([ID]) ON DELETE CASCADE
) ON WarehouseStockAvailableQtyPartitionScheme([AvailableQty]);


GO
CREATE NONCLUSTERED INDEX [IX_WarehouseStock_ProductID]
    ON [dbo].[WarehouseStock]([ProductID] ASC);


