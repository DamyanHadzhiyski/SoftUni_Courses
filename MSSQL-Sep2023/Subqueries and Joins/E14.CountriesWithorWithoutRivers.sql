SELECT TOP(5)
	c.[CountryName]
	,r.[RiverName]
FROM [Countries] as c
	LEFT JOIN [CountriesRivers] AS cr ON c.[CountryCode] = cr.[CountryCode]
	LEFT JOIN [Rivers] AS r ON r.[Id] = cr.[RiverId]
	JOIN [Continents] AS ct ON ct.[ContinentCode] = c.[ContinentCode]
WHERE ct.[ContinentName] = 'Africa'
ORDER BY c.[CountryName]