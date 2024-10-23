CREATE OR ALTER PROC usp_GetEmployeesFromTown
	(@TownName NVARCHAR(50))
AS
(SELECT 
	e.[FirstName]
	,e.[LastName]
FROM [Employees] e
	JOIN [Addresses] a ON e.[AddressID] = a.[AddressID]
	JOIN [Towns] t ON a.[TownID] = t.[TownID]
WHERE LOWER(t.[Name]) = LOWER(@TownName))