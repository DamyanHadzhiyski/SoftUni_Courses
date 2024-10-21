--TASK2
CREATE TABLE [Models] (
	[ModelID] INT PRIMARY KEY IDENTITY(101,1)
	,[Name] NVARCHAR(50) NOT NULL
	,[ManufacturerID] INT 
)

CREATE TABLE [Manufacturers] (
	[ManufacturerID] INT PRIMARY KEY IDENTITY(1,1)
	,[Name] NVARCHAR(50) NOT NULL
	,[EstablishedOn] NVARCHAR(10)
)

INSERT INTO [Models]
	VALUES
	('X1', 1)
	,('I6', 1)
	,('Model S', 2)
	,('Model X', 2)
	,('Model 3', 2)
	,('Nova', 3)

INSERT INTO [Manufacturers]
	VALUES
('BMW','07/03/1916')
,('Tesla','01/01/2003')
,('Lada','01/05/1966')

ALTER TABLE [Models]
ADD CONSTRAINT FK_ManufacturerID
FOREIGN KEY (ManufacturerID) REFERENCES [Manufacturers]([ManufacturerID])