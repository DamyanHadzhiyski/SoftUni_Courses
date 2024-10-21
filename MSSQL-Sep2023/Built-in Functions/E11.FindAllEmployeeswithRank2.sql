SELECT 
	*
FROM (Select 
	[EmployeeID]
	,[FirstName]
	,[LastName]
	,[Salary]
	,DENSE_RANK() 
	OVER (PARTITION BY [Salary] ORDER BY [EmployeeID]) AS [Rank]
FROM [Employees]
WHERE [Salary] BETWEEN 10000 AND 50000) AS t1
WHERE t1.[Rank] = 2
ORDER BY [Salary] DESC