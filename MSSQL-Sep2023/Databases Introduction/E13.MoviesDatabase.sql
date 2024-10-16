CREATE TABLE [Directors] (
	[Id] INT PRIMARY KEY IDENTITY,
	[DirectorName] NVARCHAR(50) NOT NULL,
	[Notes] NVARCHAR(MAX)
)

CREATE TABLE [Genres] (
	[Id] INT PRIMARY KEY IDENTITY,
	[GenreName] NVARCHAR(50) NOT NULL,
	[Notes] NVARCHAR(MAX)
)

CREATE TABLE [Categories] (
	[Id] INT PRIMARY KEY IDENTITY,
	[CategoryName] NVARCHAR(50) NOT NULL,
	[Notes] NVARCHAR(MAX)
)

CREATE TABLE [Movies] (
	[Id] INT PRIMARY KEY IDENTITY,
	[Title] NVARCHAR(50) NOT NULL,
	[DirectorId] INT FOREIGN KEY REFERENCES [Directors]([Id]),
	[CopyrightYear] INT,
	[Length] TIME NOT NULL,
	[GenreId] INT FOREIGN KEY REFERENCES [Genres]([Id]),
	[CategoryId] INT FOREIGN KEY REFERENCES [Categories]([Id]),
	[Rating] Decimal(3,1) NOT NULL,
	[Notes] NVARCHAR(MAX)
)

INSERT INTO [Directors]([DirectorName])
	VALUES
('Director1'),
('Director2'),
('Director3'),
('Director4'),
('Director5')

INSERT INTO [Categories]([CategoryName])
	VALUES
('Category1'),
('Category2'),
('Category3'),
('Category4'),
('Category5')

INSERT INTO [Genres]([GenreName])
	VALUES
('Genre1'),
('Genre2'),
('Genre3'),
('Genre4'),
('Genre5')

INSERT INTO [Movies]([Title],[DirectorId],[Length],[GenreId],[CategoryId],[Rating])
	VALUES
('Title1',5,'2:35',3,5,9.8),
('Title2',4,'3:05',4,4,10.0),
('Title3',1,'1:55',5,3,4.2),
('Title4',2,'3:12',1,2,9.5),
('Title5',3,'2:42',2,1,3.0)