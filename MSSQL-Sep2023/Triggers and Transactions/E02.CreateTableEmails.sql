CREATE TABLE [NotificationEmails] (
	[Id] INT PRIMARY KEY IDENTITY
	,[Recipient] INT FOREIGN KEY REFERENCES [Accounts](Id) NOT NULL
	,[Subject] NVARCHAR(400) NOT NULL
	,[Body] NVARCHAR(400) NOT NULL
)
GO

CREATE OR ALTER TRIGGER tr_SendEmailOnNewLog
ON [Logs] FOR INSERT
AS
	INSERT INTO [NotificationEmails]([Recipient], [Subject], [Body])
	SELECT 
		i.[AccountId]
		,CONCAT('Balance change for account: ', i.[AccountId])
		,CONCAT('On ', GETDATE(), ' your balance was changed from ', i.[OldSum], ' to ', i.[NewSum],'."')
	FROM inserted AS i
GO