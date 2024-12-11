CREATE PARTITION FUNCTION OrderYearPartitionFunction (DATETIME)
AS RANGE LEFT FOR VALUES ('2022-12-31', '2023-12-31', '2024-12-31');

/*
This creates partitions:

Partition 1: All rows with OrderDate <= 2022-12-31.
Partition 2: Rows with OrderDate between 2023-01-01 and 2023-12-31.
Partition 3: Rows with OrderDate between 2024-01-01 and 2024-12-31.
Partition 4: Rows with OrderDate >= 2025-01-01.
*/

Go
CREATE PARTITION SCHEME OrderYearPartitionScheme
AS PARTITION OrderYearPartitionFunction
ALL TO ([PRIMARY]);
 
Go
CREATE TABLE [dbo].[Order] (
    [ID]        VARCHAR(100) NOT NULL,
    [OrderDate] DATETIME NOT NULL
) ON OrderYearPartitionScheme(OrderDate);

Go
INSERT INTO [dbo].[Order] ([ID], [OrderDate])
VALUES 
('ID1', '2022-01-15'), ('ID2', '2022-02-20'), ('ID3', '2022-03-30'),
('ID4', '2022-04-05'), ('ID5', '2022-05-10'), ('ID6', '2022-06-15'),
('ID7', '2022-07-20'), ('ID8', '2022-08-25'), ('ID9', '2022-09-30'), ('ID10', '2022-10-31'),

('ID11', '2023-01-15'), ('ID12', '2023-02-20'), ('ID13', '2023-03-30'),
('ID14', '2023-04-05'), ('ID15', '2023-05-10'), ('ID16', '2023-06-15'),
('ID17', '2023-07-20'), ('ID18', '2023-08-25'), ('ID19', '2023-09-30'), ('ID20', '2023-10-31'),

('ID21', '2024-01-15'), ('ID22', '2024-02-20'), ('ID23', '2024-03-30'),
('ID24', '2024-04-05'), ('ID25', '2024-05-10'), ('ID26', '2024-06-15'),
('ID27', '2024-07-20'), ('ID28', '2024-08-25'), ('ID29', '2024-09-30'), ('ID30', '2024-10-31');

Go
SELECT * FROM [dbo].[Order];

Go
SELECT 
    $PARTITION.OrderYearPartitionFunction(OrderDate) AS PartitionID,
    *
FROM [dbo].[Order]
WHERE $PARTITION.OrderYearPartitionFunction(OrderDate) = 1; -- Partition 1 (2022)


Go
SELECT *
FROM [dbo].[Order]
WHERE OrderDate = '2022-05-10'; 


/* IF we need to do partition on Year not date THEN 

CREATE PARTITION FUNCTION OrderYearPartitionFunction (INT)
AS RANGE LEFT FOR VALUES (2022, 2023, 2024);

Go
CREATE PARTITION SCHEME OrderYearPartitionScheme
AS PARTITION OrderYearPartitionFunction
ALL TO ([PRIMARY]);

Go
CREATE TABLE [dbo].[Orders] (
    [ID]        VARCHAR(100) NOT NULL,
    [OrderDate] DATETIME NOT NULL,
    [OrderYear] AS YEAR(OrderDate) PERSISTED -- Computed column for year
) ON OrderYearPartitionScheme(OrderYear);

*/