CREATE TABLE [Logs] (
	[LogId] INT PRIMARY KEY IDENTITY
	,[AccountId] INT FOREIGN KEY REFERENCES [Accounts](Id)
	,[OldSum] DECIMAL(18,2) NOT NULL
	,[NewSum] DECIMAL(18,2) NOT NULL
)
GO

CREATE OR ALTER TRIGGER tr_AddToLogsOnAccountUpdate
ON [Accounts] FOR UPDATE
AS
	INSERT INTO [Logs](AccountId, OldSum, NewSum)
	SELECT i.[Id], d.[Balance], i.[Balance]
	FROM inserted AS i
		JOIN deleted AS d ON i.[Id] = d.[Id]
	WHERE i.[Balance] <> d.[Balance]