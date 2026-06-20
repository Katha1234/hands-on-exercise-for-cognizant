-- --- Step 1: Create Stored Procedure to Return Employee Count ---
CREATE PROCEDURE sp_GetEmployeeCountByDepartment
    @DepartmentID INT
AS
BEGIN
    SET NOCOUNT ON;
    
    -- Write the SQL query to count the number of employees in the specified department
    SELECT 
        COUNT(EmployeeID) AS TotalEmployees
    FROM 
        Employees
    WHERE 
        DepartmentID = @DepartmentID;
END;
GO

-- --- Step 2: Sample Execution Tests ---
-- Test 1: Get total employee count for HR (DepartmentID = 1)
EXEC sp_GetEmployeeCountByDepartment @DepartmentID = 1;

-- Test 2: Get total employee count for IT (DepartmentID = 3)
EXEC sp_GetEmployeeCountByDepartment @DepartmentID = 3;