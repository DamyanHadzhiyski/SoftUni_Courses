SELECT 
	SUM(dt.[diff]) [SumDifference]
FROM 
	(SELECT 
		[DepositAmount] - Lead([DepositAmount]) OVER (ORDER BY [Id]) [diff]
	FROM [WizzardDeposits]) AS dt