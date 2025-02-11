SELECT 
	[DepositGroup]
	,[isDepositExpired]
	,AVG([DepositInterest]) [AverageInterest]
FROM [WizzardDeposits]
WHERE [DepositStartDate] > '1985-01-01'
GROUP BY [DepositGroup], [isDepositExpired]
ORDER BY [DepositGroup] DESC, [IsDepositExpired]