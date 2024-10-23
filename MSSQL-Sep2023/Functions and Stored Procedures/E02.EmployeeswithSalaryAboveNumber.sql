CREATE OR ALTER PROC usp_GetEmployeesSalaryAboveNumber
	(@AboveValue DECIMAL(18,4))
AS
(SELECT 
	[FirstName]
	,[LastName]
FROM [Employees]
WHERE [Salary] >= @AboveValue)