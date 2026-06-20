-- --- Step 1: Create Stored Procedure to Retrieve Employees by Department ---
CREATE PROCEDURE sp_GetEmployeesByDepartment
    @DepartmentID INT
AS
BEGIN
    SET NOCOUNT ON;
    
    SELECT 
        EmployeeID,
        FirstName,
        LastName,
        Salary,
        JoinDate
    FROM 
        Employees
    WHERE 
        DepartmentID = @DepartmentID;
END;
GO

-- --- Step 2: Create Stored Procedure to Insert a New Employee ---
CREATE PROCEDURE sp_InsertEmployee
    @FirstName VARCHAR(50),
    @LastName VARCHAR(50),
    @DepartmentID INT,
    @Salary DECIMAL(10,2),
    @JoinDate DATE
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO Employees (FirstName, LastName, DepartmentID, Salary, JoinDate)
    VALUES (@FirstName, @LastName, @DepartmentID, @Salary, @JoinDate);
END;
GO

-- --- Step 3: Sample Execution Tests ---
-- Test 1: Retrieve all IT Employees (DepartmentID = 3)
EXEC sp_GetEmployeesByDepartment @DepartmentID = 3;

-- Test 2: Add a new employee into the Finance Department (DepartmentID = 2)
EXEC sp_InsertEmployee 
    @FirstName = 'Robert', 
    @LastName = 'Miller', 
    @DepartmentID = 2, 
    @Salary = 6500.00, 
    @JoinDate = '2026-06-20';