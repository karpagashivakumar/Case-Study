-- Step 1: Create Main Table
CREATE TABLE Employees (
    EmpID INT PRIMARY KEY,
    EmpName VARCHAR(100),
    Department VARCHAR(50),
    Salary DECIMAL(10, 2)
);

-- Step 2: Create Audit Table
CREATE TABLE EmployeeAuditLog (
    LogID INT IDENTITY(1,1) PRIMARY KEY,
    EmpID INT,
    EmpName VARCHAR(100),
    Department VARCHAR(50),
    Salary DECIMAL(10,2),
    ActionType VARCHAR(10),
    ActionDate DATETIME DEFAULT GETDATE()
);

-- Step 3: Create INSERT Trigger
CREATE TRIGGER trg_Audit_Insert
ON Employees
AFTER INSERT
AS
BEGIN
    INSERT INTO EmployeeAuditLog (EmpID, EmpName, Department, Salary, ActionType)
    SELECT EmpID, EmpName, Department, Salary, 'INSERT'
    FROM INSERTED;
END;

-- Step 4: Create DELETE Trigger
CREATE TRIGGER trg_Audit_Delete
ON Employees
AFTER DELETE
AS
BEGIN
    INSERT INTO EmployeeAuditLog (EmpID, EmpName, Department, Salary, ActionType)
    SELECT EmpID, EmpName, Department, Salary, 'DELETE'
    FROM DELETED;
END;

-- Step 5: Test the Triggers
INSERT INTO Employees (EmpID, EmpName, Department, Salary)
VALUES (101, 'Alice', 'HR', 50000.00),
       (102, 'Bob', 'IT', 70000.00);

DELETE FROM Employees WHERE EmpID = 101;

-- Step 6: Check the Audit Log
SELECT * FROM EmployeeAuditLog;