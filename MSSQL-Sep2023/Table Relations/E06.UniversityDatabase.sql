CREATE TABLE [Majors] (
	[MajorID] INT PRIMARY KEY IDENTITY
	,[Name]	NVARCHAR(100) NOT NULL
)

CREATE TABLE [Subjects] (
	[SubjectID] INT PRIMARY KEY IDENTITY
	,[SubjectName] NVARCHAR(100) NOT NULL
)

CREATE TABLE [Payments] (
	[PaymentID] INT PRIMARY KEY IDENTITY
	,[PaymentDate] DATE NOT NULL
	,[PaymentAmount] DECIMAL (6,2) NOT NULL
	,[StudentID] INT NOT NULL
)

CREATE TABLE [Students] (
	[StudentID] INT PRIMARY KEY IDENTITY
	,[StudentNumber] INT NOT NULL
	,[StudentName] NVARCHAR(100) NOT NULL
	,[MajorID] INT
)

CREATE TABLE [Agenda] (
	[StudentID] INT NOT NULL
	,[SubjectID] INT NOT NULL
)

ALTER TABLE [Students]
ADD CONSTRAINT FK_Students_Majors
FOREIGN KEY ([MajorID]) REFERENCES [Majors]([MajorID])

ALTER TABLE [Payments]
ADD CONSTRAINT FK_Payments_Students
FOREIGN KEY ([StudentID]) REFERENCES [Students]([StudentID])

ALTER TABLE [Agenda]
ADD CONSTRAINT FK_Agenda_Students
FOREIGN KEY ([StudentID]) REFERENCES [Students]([StudentID])

ALTER TABLE [Agenda]
ADD CONSTRAINT FK_Agenda_Subjects
FOREIGN KEY ([SubjectID]) REFERENCES [Subjects]([SubjectID])

ALTER TABLE [Agenda]
ADD CONSTRAINT PK_StudentID_SubjectID
PRIMARY KEY ([StudentID], [SubjectID])