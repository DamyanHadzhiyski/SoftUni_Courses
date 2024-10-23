CREATE OR ALTER PROC usp_DeleteEmployeesFromDepartment(@departmentId INT)

AS
	DECLARE @employeesToDelete TABLE(Id INT)

	INSERT INTO @employeesToDelete(Id)
	SELECT [EmployeeID]
	FROM [Employees]
	WHERE [DepartmentID] = @departmentId

	ALTER TABLE [Departments]
	ALTER COLUMN [ManagerID] INT NULL

	UPDATE [Departments]
	SET [ManagerID] = NULL
	WHERE [ManagerID] IN (SELECT * FROM @employeesToDelete)

	UPDATE [Employees]
	SET [ManagerID] = NULL
	WHERE [ManagerID] IN (SELECT * FROM @employeesToDelete)

	DELETE
	FROM [EmployeesProjects]
	WHERE [EmployeeID] IN (SELECT * FROM @employeesToDelete)

	DELETE
	FROM [Employees]
	WHERE [DepartmentId] = @departmentId

	DELETE
	FROM [Departments]
	WHERE [DepartmentId] = @departmentId
GO