SELECT TOP(5)
	dt.[CountryName]
	,CASE 
		WHEN dt.[PeakName] IS NULL THEN '(no highest peak)'
			 ELSE dt.[PeakName]
		END
	,CASE 
		WHEN dt.[Elevation] IS NULL THEN '0'
			 ELSE dt.[Elevation]
		END
	,CASE 
		WHEN dt.[MountainRange] IS NULL THEN '(no mountain)'
			 ELSE dt.[MountainRange]
		END
FROM 
	(SELECT 
		c.[CountryName]
		,p.[PeakName]
		,p.[Elevation]
		,m.[MountainRange]
		,DENSE_RANK() OVER (PARTITION BY c.[CountryName] ORDER BY p.[Elevation] DESC) AS [Peaks_Rank]
	FROM [Countries] AS c
		left JOIN [MountainsCountries] AS mc ON c.[CountryCode] = mc.[CountryCode]
		left JOIN [Mountains] AS m ON mc.[MountainId] = m.[Id]
		left JOIN [Peaks] AS p ON m.[Id] = p.[MountainId]) 
	AS dt
WHERE dt.[Peaks_Rank] = 1
ORDER BY dt.[CountryName], dt.[PeakName]