CREATE OR ALTER PROC usp_CalculateFutureValueForAccount
	(@accountID INT, @rate FLOAT)
AS
SELECT
	a.[Id]
	,ah.[FirstName]
	,ah.[LastName]
	,SUM(a.[Balance]) as [Current Balance]
	,dbo.ufn_CalculateFutureValue(SUM(a.[Balance]), @rate, 5) as [Balance in 5 years]
FROM [Accounts] a
	JOIN [AccountHolders] ah ON a.[AccountHolderId] = ah.[Id]
GROUP BY a.[Id], ah.[FirstName], ah.[LastName]
HAVING a.[Id] = @accountID