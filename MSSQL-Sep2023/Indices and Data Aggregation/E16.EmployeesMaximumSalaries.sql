SELECT 
	[DepartmentID]
	,MAX([Salary]) [MaxSalary]
FROM [Employees]
GROUP BY [DepartmentID]
HAVING MAX([Salary]) NOT BETWEEN 30000 AND 70000
ORDER BY [DepartmentID]