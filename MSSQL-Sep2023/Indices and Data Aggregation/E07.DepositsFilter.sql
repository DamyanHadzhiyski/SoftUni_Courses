SELECT
	[DepositGroup]
	,SUM([DEPOSITAMOUNT]) AS [TotalSum]
FROM [WizzardDeposits]
WHERE [MagicWandCreator] = 'Ollivander family' 
GROUP BY [DepositGroup]
HAVING SUM([DEPOSITAMOUNT]) < 150000
ORDER BY [TotalSum] DESC