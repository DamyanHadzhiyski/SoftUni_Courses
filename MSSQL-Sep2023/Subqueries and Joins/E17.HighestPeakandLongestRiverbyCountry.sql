SELECT TOP(5)
	TEST.CountryName
	,TEST.Elevation HighestPeakElevation
	,TEST.Length LongestRiverLength
FROM (SELECT 
	c.[CountryName]
	,p.[Elevation]
	,r.[Length]
	,DENSE_RANK() OVER (PARTITION BY c.[CountryName] ORDER BY p.[Elevation] desc, r.[Length] desc) AS [RANK]
FROM [Countries] AS c
	left JOIN [MountainsCountries] AS mc ON c.[CountryCode] = mc.[CountryCode]
	left JOIN [Peaks] AS p ON mc.[MountainId] = p.[MountainId]
	left JOIN [CountriesRivers] AS cr ON c.[CountryCode] = cr.[CountryCode]
	left JOIN [Rivers] AS r ON cr.[RiverId] = r.[Id]) AS [TEST]
WHERE TEST.[RANK] = 1
ORDER BY TEST.[Elevation] DESC, TEST.[Length] DESC, TEST.[CountryName]