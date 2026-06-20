-- --- Step 1: Setup Mock Data Schema & Table ---
CREATE TABLE Products (
    ProductID INT PRIMARY KEY,
    ProductName VARCHAR(100),
    Category VARCHAR(50),
    Price DECIMAL(10, 2)
);

-- Insert dummy records including prices that tie to test ranking logic
INSERT INTO Products (ProductID, ProductName, Category, Price) VALUES
(1, 'Gaming Laptop', 'Electronics', 1500.00),
(2, 'OLED Monitor', 'Electronics', 800.00),
(3, '4K TV', 'Electronics', 1500.00), -- Tie for 1st
(4, 'Wireless Mouse', 'Electronics', 50.00),
(5, 'Mechanical Keyboard', 'Electronics', 150.00),
(6, 'Ergonomic Chair', 'Furniture', 450.00),
(7, 'Standing Desk', 'Furniture', 600.00),
(8, 'Leather Sofa', 'Furniture', 1200.00),
(9, 'Bookshelf', 'Furniture', 150.00),
(10, 'Office Lamp', 'Furniture', 150.00); -- Tie for 4th

-- --- Step 2: Use Window and Ranking Functions ---
WITH RankedProducts AS (
    SELECT 
        Category,
        ProductName,
        Price,
        -- 1. Unique sequential ranking regardless of price ties
        ROW_NUMBER() OVER (PARTITION BY Category ORDER BY Price DESC) AS RowNum,
        
        -- 2. Standard rank (leaves gaps in ranking numbers after a tie)
        RANK() OVER (PARTITION BY Category ORDER BY Price DESC) AS RankNum,
        
        -- 3. Dense rank (no gaps in ranking numbers after a tie)
        DENSE_RANK() OVER (PARTITION BY Category ORDER BY Price DESC) AS DenseRankNum
    FROM 
        Products
)
-- --- Step 3: Filter for Top 3 Most Expensive Items per Category ---
SELECT 
    Category,
    ProductName,
    Price,
    RowNum,
    RankNum,
    DenseRankNum
FROM 
    RankedProducts
WHERE 
    DenseRankNum <= 3; -- Using DenseRank to guarantee all tied top products are captured safely