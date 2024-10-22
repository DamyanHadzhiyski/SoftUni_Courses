SELECT
	[DepositGroup]
	,SUM([DEPOSITAMOUNT]) AS [TotalSum]
FROM [WizzardDeposits]
GROUP BY [DepositGroup]