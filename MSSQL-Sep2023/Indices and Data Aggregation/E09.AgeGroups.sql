SELECT 
	r.AgeGroup
	,COUNT(r.[AgeGroup]) AS [WizardCount]
FROM
	(SELECT
		[AgeGroup] = 
			CASE
				WHEN [Age] >= 0 AND [Age] <= 10 THEN '[0-10]'
				WHEN [Age] >= 11 AND [Age] <= 20 THEN '[11-20]'
				WHEN [Age] >= 21 AND [Age] <= 30 THEN '[21-30]'
				WHEN [Age] >= 31 AND [Age] <= 40 THEN '[31-40]'
				WHEN [Age] >= 41 AND [Age] <= 50 THEN '[41-50]'
				WHEN [Age] >= 51 AND [Age] <= 60 THEN '[51-60]'
				WHEN [Age] >= 61 THEN '[61+]'
			END
	FROM [WizzardDeposits]) AS r
GROUP BY R.[AgeGroup]