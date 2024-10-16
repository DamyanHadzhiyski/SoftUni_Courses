CREATE TABLE [Users] (
	[Id] BIGINT PRIMARY KEY IDENTITY,
	[Username] NVARCHAR(30) NOT NULL,
	[PassWord] NVARCHAR(26) NOT NULL,
	[ProfilePicture] VARBINARY,
	CHECK (DATALENGTH([ProfilePicture]) <= 900000),
	[LastLoginTime] DATETIME2,
	[IsDeleted] VARCHAR(5),
	CHECK ([IsDeleted] = 'true' OR [IsDeleted] = 'false')
)

INSERT INTO [Users]([Username],[PassWord])
	VALUES
('Ivan', '1989-02-19'),
('Martin', '1984-03-19'),
('Galya', '1989-05-19'),
('Maria', '1982-06-19'),
('Atanas', '1994-07-19')