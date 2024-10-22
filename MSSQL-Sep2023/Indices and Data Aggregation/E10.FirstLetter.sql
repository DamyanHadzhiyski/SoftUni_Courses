SELECT
	r.[FirstLetter]
FROM 
	(SELECT 
		SUBSTRING([FirstName],1,1) AS [FirstLetter]
	 FROM [Gringotts].[dbo].[WizzardDeposits]
	 WHERE [DepositGroup] = 'Troll Chest') AS r
GROUP BY r.[FirstLetter]
ORDER BY r.[FirstLetter]