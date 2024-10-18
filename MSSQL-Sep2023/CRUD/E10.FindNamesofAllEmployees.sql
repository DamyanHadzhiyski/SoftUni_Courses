SELECT 
	CONCAT_WS(' ',[FirstName],[MiddleName],[LastName]) AS [Full Name]
FROM [Employees]
WHERE [Salary] IN (25000,23600,14000,12500)