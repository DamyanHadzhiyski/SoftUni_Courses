SELECT 
	MIN(ave) as MinAverageSalary
FROM 
	(SELECT 
		AVG([Salary]) as ave
	FROM [Employees]
	GROUP BY [DepartmentID]) as e