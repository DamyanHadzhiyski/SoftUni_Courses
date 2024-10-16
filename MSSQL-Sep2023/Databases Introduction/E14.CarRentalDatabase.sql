CREATE TABLE [Categories] (
	[Id] INT PRIMARY KEY IDENTITY,
	[CategoryName] NVARCHAR(30) NOT NULL,
	[DailyRate] DECIMAL(5,2) NOT NULL,
	[WeeklyRate] DECIMAL(6,2) NOT NULL,
	[MonthlyRate] DECIMAL(7,2) NOT NULL,
	[WeekendRate] DECIMAL(6,2) NOT NULL
)

CREATE TABLE [Employees] (
	[Id] INT PRIMARY KEY IDENTITY,
	[FirstName] NVARCHAR(30) NOT NULL,
	[LastName] NVARCHAR(60) NOT NULL,
	[Title] NVARCHAR(10),
	[Notes] NVARCHAR(MAX)
)

CREATE TABLE [Customers] (
	[Id] INT PRIMARY KEY IDENTITY,
	[DriverLicenceNumber] NVARCHAR(30) NOT NULL,
	[FullName] NVARCHAR(200) NOT NULL,
	[Address] NVARCHAR(200) NOT NULL,
	[City] NVARCHAR(30) NOT NULL,
	[ZIPCode] NVARCHAR(10),
	[Notes] NVARCHAR(MAX)
)

CREATE TABLE [Cars] (
	[Id] INT PRIMARY KEY IDENTITY,
	[PlateNumber] NVARCHAR(30) NOT NULL,
	[Manufacturer] NVARCHAR(30) NOT NULL,
	[Model] NVARCHAR(30) NOT NULL,
	[CarYear] INT,
	[CategoryId] INT FOREIGN KEY REFERENCES [Categories]([Id]),
	[Doors] INT NOT NULL,
	[Picture] VARBINARY,
	[Condition] VARCHAR(4) NOT NULL,
	CHECK ([Condition] = 'GOOD' OR [Condition] = 'BAD'),
	[Available] char(1) NOT NULL,
	CHECK ([Available] = 't' OR [Available] = 'f')
)

CREATE TABLE [RentalOrders] (
	[Id] INT PRIMARY KEY IDENTITY,
	[EmployeeId] INT FOREIGN KEY REFERENCES [Employees]([Id]),
	[CustomerId] INT FOREIGN KEY REFERENCES [Customers]([Id]),
	[CarId] INT FOREIGN KEY REFERENCES [Cars]([Id]),
	[TankLevel] INT NOT NULL,
	[KilometrageStart] INT NOT NULL,
	[KilometrageEnd] INT NOT NULL,
	[TotalKilometrage] INT NOT NULL,
	[StartDate] DATETIME2 NOT NULL,
	[EndDate] DATETIME2 NOT NULL,
	[TotalDays] INT NOT NULL,
	[RateApplied] VARCHAR(20),
	[TaxRate] DECIMAL(4,2) NOT NULL,
	[OrderStatus] NVARCHAR(11) NOT NULL,
	CHECK ([OrderStatus] = 'COMPLETE' OR [OrderStatus] = 'IN PROGRESS'),
	[Notes] NVARCHAR(MAX)
)

INSERT INTO [Categories]([CategoryName],[DailyRate],[WeeklyRate],[MonthlyRate],[WeekendRate])
	VALUES
('Category1',1,2,3,4),
('Category2',5,6,7,8),
('Category3',9,10,11,12)

INSERT INTO [Employees]([FirstName],[LastName])
	VALUES
('Employee1', 'Employee1'),
('Employee2', 'Employee2'),
('Employee3', 'Employee3')

INSERT INTO [Customers]([DriverLicenceNumber],[FullName],[Address],[City])
	VALUES
('LicenceNumber1', 'Driver1','Address1', 'City1'),
('LicenceNumber2', 'Driver2','Address2', 'City2'),
('ELicenceNumber3', 'Driver3','Address3', 'City3')

INSERT INTO [Cars]([PlateNumber],[Manufacturer],[Model],[CategoryId],[Doors],[Condition],[Available])
	VALUES
('PlateNumber1', 'Manufacturer1','Model1',3,5,'GOOD','T'),
('PlateNumber2', 'Manufacturer2','Model2',2,5,'GOOD','T'),
('PlateNumber3', 'Manufacturer3','Model3',1,3,'BAD','F')

INSERT INTO [RentalOrders]([EmployeeId],[CustomerId],[CarId],[TankLevel],[KilometrageStart],[KilometrageEnd],[TotalKilometrage],[StartDate],[EndDate],[TotalDays],[RateApplied],[TaxRate],[OrderStatus])
	VALUES
(2,3,1,32,1234,4321,5000,'1900-01-01 00:00:00','1900-01-11 00:00:00',10,'WeeklyRate',1.5,'IN PROGRESS'),
(1,2,3,42,1234,4321,4000,'1900-01-01 00:00:00','1900-01-03 00:00:00',2,'WeeklyRate',1.2,'COMPLETE'),
(1,2,3,42,1234,4321,4000,'1920-01-01 00:00:00','1900-01-03 00:00:00',2,'WeeklyRate',1.2,'COMPLETE')