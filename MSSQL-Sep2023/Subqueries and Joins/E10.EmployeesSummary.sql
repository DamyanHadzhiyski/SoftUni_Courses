SELECT TOP(50)
	e.[EmployeeID]
	,CONCAT_WS(' ',e.[FirstName],e.[LastName]) AS [EmployeeName]
	,CONCAT_WS(' ',m.[FirstName],m.[LastName]) AS [ManageName]
	,d.[Name] AS [DepartmentName]
FROM [Employees] AS e
	JOIN [Employees] AS m ON m.[EmployeeID] = e.[ManagerID]
	JOIN [Departments] AS d ON e.[DepartmentID] = d.[DepartmentID]
ORDER BY e.[EmployeeID]