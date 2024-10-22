SELECT TOP (2)
	[DepositGroup]
FROM [WIZZARDDEPOSITS]
GROUP BY [DepositGroup]
ORDER BY AVG([MagicWandSize])