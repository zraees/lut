---====== Partition on Product based on Category =====================
Go
SELECT 
    $PARTITION.ProductCategoryPartitionFunction(Category) AS PartitionID,
    *
FROM [dbo].Product
WHERE $PARTITION.ProductCategoryPartitionFunction(Category) = 3; -- Partition 1 (Accessories)

-- complete Data
SELECT * FROM [dbo].Product

---====== Partition on UserAccount based on Active =====================
Go
SELECT 
    $PARTITION.UserAccountActivePartitionFunction(Active) AS PartitionID,
    *
FROM [dbo].UserAccount
WHERE $PARTITION.UserAccountActivePartitionFunction(Active) = 2; -- Partition 1 (In-Active)

-- complete Data
SELECT * FROM [dbo].UserAccount


---====== Partition on Order based on Order Date =====================
Go
SELECT 
    $PARTITION.OrderDatePartitionFunction(OrderDate) AS PartitionID,
    *
FROM [dbo].[Order]
WHERE $PARTITION.OrderDatePartitionFunction(OrderDate) = 3; -- Partition 1 (2022)

-- complete Data
SELECT * FROM [dbo].[Order]


---====== Partition on WarehouseStock based on AvailableQty =====================
Go
SELECT 
    $PARTITION.WarehouseStockAvailableQtyPartitionFunction(AvailableQty) AS PartitionID,
    *
FROM [dbo].WarehouseStock
WHERE $PARTITION.WarehouseStockAvailableQtyPartitionFunction(AvailableQty) = 2; -- Partition 1 (2022)

-- complete Data
SELECT * FROM [dbo].WarehouseStock

