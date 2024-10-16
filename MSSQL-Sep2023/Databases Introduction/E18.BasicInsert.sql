INSERT INTO [Towns]([Name]) 
	VALUES
	('Sofia'),
	('Plovdiv'),
	('Varna'),
	('Burgas')

INSERT INTO [Departments]([Name]) 
	VALUES
	('Engineering'),
	('Sales'),
	('Marketing'),
	('Software Development'),
	('Quality Assurance')
GO

INSERT INTO [Employees]([FirstName],[MiddleName],[LastName],[JobTitle],[DepartmentId],[HireDate],[Salary]) 
	VALUES
	('Ivan','Ivanov','Ivanov','.NET Developer',4,'2013-02-01',3500.00),
	('Petar','Petrov','Petrov','Senior Developer',1,'2004-03-02',4000.00),
	('Maria','Petrova','Ivanova','Intern',5,'2016-08-28',525.25),
	('Georgi','Terziev','Ivanov','CEO',2,'2007-12-09',3000.00),
	('Petar','Pan','Pan','Intern',3,'2016-08-28',599.88)
GO