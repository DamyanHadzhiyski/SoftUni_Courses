SELECT
	[DepositGroup]
	,SUM([DEPOSITAMOUNT]) AS [TotalSum]
FROM [WizzardDeposits]
WHERE [MagicWandCreator] = 'Ollivander family'
GROUP BY [DepositGroup]