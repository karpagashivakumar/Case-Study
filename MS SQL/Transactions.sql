-- 1. Step 1: Create Tables
-- Orders Table
CREATE TABLE Orders (
    OrderID INT IDENTITY(1,1) PRIMARY KEY,
    CustomerName VARCHAR(100),
    OrderDate DATETIME DEFAULT GETDATE()
);

-- OrderItems Table
CREATE TABLE OrderItems (
    OrderItemID INT IDENTITY(1,1) PRIMARY KEY,
    OrderID INT FOREIGN KEY REFERENCES Orders(OrderID),
    ProductName VARCHAR(100),
    Quantity INT,
    UnitPrice DECIMAL(10,2)
);

-- 2. Step 2: Insert Data Using Transaction
BEGIN TRY
    BEGIN TRANSACTION;

    -- Insert into Orders table
    INSERT INTO Orders (CustomerName)
    VALUES ('John Doe');

    -- Get the newly generated OrderID
    DECLARE @NewOrderID INT = SCOPE_IDENTITY();

    -- Insert multiple OrderItems
    INSERT INTO OrderItems (OrderID, ProductName, Quantity, UnitPrice)
    VALUES 
        (@NewOrderID, 'Laptop', 1, 75000.00),
        (@NewOrderID, 'Mouse', 2, 500.00),
        (@NewOrderID, 'Keyboard', 1, 1500.00);

    -- Commit transaction if everything is successful
    COMMIT TRANSACTION;
    PRINT 'Order and items inserted successfully.';
END TRY
BEGIN CATCH
    -- Rollback if any error occurs
    ROLLBACK TRANSACTION;

    PRINT 'Error occurred: ' + ERROR_MESSAGE();
END CATCH;

-- 4. Step 4: View Inserted Data
-- Check Orders
SELECT * FROM Orders;

-- Check OrderItems
SELECT * FROM OrderItems;
