SELECT 
	dt.[DepartmentID]
	,dt.[Salary] [ThirdHighestSalary]
FROM 
	(SELECT 
		[DepartmentID]
		,[Salary]
		,DENSE_RANK() OVER (PARTITION BY [DepartmentID] ORDER BY [Salary] DESC) [salary_rank]
	FROM [Employees]) dt
WHERE dt.[salary_rank] = 3
GROUP BY dt.[DepartmentID],dt.[Salary]