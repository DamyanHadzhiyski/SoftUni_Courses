CREATE TABLE [Employees] (
[Id] INT PRIMARY KEY IDENTITY,
[FirstName] NVARCHAR(30) NOT NULL,
[LastName] NVARCHAR(60) NOT NULL,
[Title] NVARCHAR(10),
[Notes] NVARCHAR(MAX)
)

CREATE TABLE [Customers] (
[AccountNumber] INT PRIMARY KEY,
[FirstName] NVARCHAR(30) NOT NULL,
[LastName] NVARCHAR(60) NOT NULL,
[PhoneNumber] NVARCHAR(50),
[EmergencyName] NVARCHAR(200),
[EmergencyNumber] NVARCHAR(50),
[Notes] NVARCHAR(MAX)
)

CREATE TABLE [RoomStatus] (
[RoomStatus] NVARCHAR(30) PRIMARY KEY,
[Notes] NVARCHAR(MAX)
)

CREATE TABLE [RoomTypes] (
[RoomType] NVARCHAR(30) PRIMARY KEY,
[Notes] NVARCHAR(MAX)
)

CREATE TABLE [BedTypes] (
[BedType] NVARCHAR(30) PRIMARY KEY,
[Notes] NVARCHAR(MAX)
)

CREATE TABLE [Rooms] (
[RoomNumber] INT PRIMARY KEY IDENTITY,
[RoomType] NVARCHAR(30) FOREIGN KEY REFERENCES [RoomTypes]([RoomType]),
[BedType] NVARCHAR(30) FOREIGN KEY REFERENCES [BedTypes]([BedType]),
[Rate] DECIMAL(5,2) NOT NULL,
[RoomStatus] NVARCHAR(30) FOREIGN KEY REFERENCES [RoomStatus]([RoomStatus]),
[Notes] NVARCHAR(MAX)
)

CREATE TABLE [Payments] (
[Id] INT PRIMARY KEY IDENTITY,
[EmployeeId] INT FOREIGN KEY REFERENCES [Employees]([Id]),
[PaymentDate] DATETIME2 NOT NULL,
[AccountNumber] INT FOREIGN KEY REFERENCES [Customers]([AccountNumber]),
[FirstDateOccupied] DATETIME2 NOT NULL,
[LastDateOccupied] DATETIME2 NOT NULL,
[TotalDays] INT NOT NULL,
[AmountCharged] DECIMAL(6,2) NOT NULL,
[TaxRate] DECIMAL(4,2) NOT NULL,
[TaxAmount] DECIMAL(5,2) NOT NULL,
[PaymentTotal] DECIMAL(6,2) NOT NULL,
[Notes] NVARCHAR(MAX)
)

CREATE TABLE [Occupancies] (
[Id] INT PRIMARY KEY IDENTITY,
[EmployeeId] INT FOREIGN KEY REFERENCES [Employees]([Id]),
[DateOccupied] DATETIME2 NOT NULL,
[AccountNumber] INT FOREIGN KEY REFERENCES [Customers]([AccountNumber]),
[RoomNumber] INT FOREIGN KEY REFERENCES [Rooms]([RoomNumber]),
[RateApplied] DECIMAL(5,2) NOT NULL,
[PhoneCharge] DECIMAL(5,2),
[Notes] NVARCHAR(MAX)
)

INSERT INTO [Employees]([FirstName],[LastName])
	VALUES
('Employee1','Employee1'),
('Employee2','Employee2'),
('Employee3','Employee3')

INSERT INTO [Customers]([AccountNumber],[FirstName],[LastName])
	VALUES
(123,'Customer1','Customer1'),
(456,'Customer2','Customer2'),
(789,'Customer3','Customer3')

INSERT INTO [RoomStatus]([RoomStatus])
	VALUES
('RoomStatus1'),
('RoomStatus2'),
('RoomStatus3')

INSERT INTO [RoomTypes]([RoomType])
	VALUES
('RoomType1'),
('RoomType2'),
('RoomType3')

INSERT INTO [BedTypes]([BedType])
	VALUES
('BedType1'),
('BedType2'),
('BedType3')

INSERT INTO [Rooms]([RoomType],[BedType],[Rate],[RoomStatus])
	VALUES
('RoomType3','BedType1',50,'RoomStatus2'),
('RoomType2','BedType3',40,'RoomStatus1'),
('RoomType1','BedType2',60,'RoomStatus3')

INSERT INTO [Occupancies]([EmployeeId],[DateOccupied],[AccountNumber],[RoomNumber],[RateApplied])
	VALUES
(2,'2023-09-16 17:32:08',456,3,60),
(3,'2023-09-16 19:47:53',789,2,70),
(1,'2023-09-17 13:38:18',123,1,80)

INSERT INTO [Payments]([EmployeeId],[PaymentDate],[AccountNumber],[FirstDateOccupied],[LastDateOccupied],[TotalDays],[AmountCharged],[TaxRate],[TaxAmount],[PaymentTotal])
	VALUES
(1,'2023-09-16 17:32:08',456,'2023-09-16 17:32:08','2023-09-16 17:32:08',10,20,1.5,20,45),
(2,'2023-09-16 17:32:08',123,'2023-09-16 17:32:08','2023-09-16 17:32:08',10,20,1.5,20,45),
(3,'2023-09-16 17:32:08',789,'2023-09-16 17:32:08','2023-09-16 17:32:08',10,20,1.5,20,45)