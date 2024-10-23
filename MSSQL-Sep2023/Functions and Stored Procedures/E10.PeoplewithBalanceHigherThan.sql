CREATE OR ALTER PROC usp_GetHoldersWithBalanceHigherThan
	(@money DECIMAL(18,4))
AS

	SELECT
		ah.[FirstName]
		,ah.[LastName]
	FROM [AccountHolders] ah
		JOIN [Accounts] a ON ah.[Id] = a.[AccountHolderId]
	GROUP BY a.[AccountHolderId], ah.[FirstName], ah.[LastName]
	HAVING SUM(a.[Balance]) > @money
	ORDER BY ah.[FirstName], ah.[LastName]