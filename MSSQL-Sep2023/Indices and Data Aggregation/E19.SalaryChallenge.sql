SELECT TOP(10)
	e.[FirstName]
	,e.[LastName]
	,e.[DepartmentID]
FROM [Employees] e
	LEFT JOIN (SELECT
				[DepartmentID]
				,AVG([Salary]) AS [avg_salary]
			FROM [Employees]
			GROUP BY [DepartmentID]) as a_s ON e.DepartmentID = a_s.DepartmentID
WHERE e.[Salary] > a_s.avg_salary
ORDER BY e.[DepartmentID]