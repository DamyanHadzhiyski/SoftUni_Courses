CREATE TABLE [People] (
	[Id] INT PRIMARY KEY IDENTITY,
	[Name]  NVARCHAR(200) NOT NULL,
	[Picture] VARBINARY,
	CHECK (DATALENGTH([Picture]) <= 2000000),
	[Height] DECIMAL(3,2),
	[Weight] DECIMAL(5,2),
	[Gender] CHAR(1) NOT NULL,
	CHECK ([Gender] = 'm' OR [Gender] = 'f'),
	[Birthdate] DATE NOT NULL,
	[Biography] NVARCHAR(MAX)
)

INSERT INTO [People]([Name],[Height],[Weight],[Gender],[Birthdate])
	VALUES
('Ivan', 1.84, 92, 'm', '1989-02-19'),
('Martin', 1.81, 76, 'm', '1984-03-19'),
('Galya', 1.54, 40, 'f', '1989-05-19'),
('Maria', 1.60, 46, 'f', '1982-06-19'),
('Atanas', 1.98, 134.5, 'm', '1994-07-19')