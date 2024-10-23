CREATE OR ALTER PROC usp_EmployeesBySalaryLevel
	(@SalaryLevel VARCHAR(10))
AS
(SELECT 
	e.[FirstName]
	,e.[LastName]
FROM [Employees] e
WHERE LOWER(dbo.ufn_GetSalaryLevel([Salary])) = LOWER(@SalaryLevel))