SELECT
	c.[CountryCode]
	,COUNT(*)
FROM [MountainsCountries] AS mc
	JOIN [Countries] AS c ON c.[CountryCode] = mc.[CountryCode]
WHERE c.[CountryName] IN ('Bulgaria','Russia','United States')
GROUP BY c.[CountryCode]