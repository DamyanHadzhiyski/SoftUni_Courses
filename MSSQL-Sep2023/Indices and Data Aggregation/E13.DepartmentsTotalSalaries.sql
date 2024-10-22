SELECT 
	[DepartmentID]
	,SUM([Salary]) [TotalSalary]
FROM [Employees]
GROUP BY [DepartmentID]
ORDER BY [DepartmentID]