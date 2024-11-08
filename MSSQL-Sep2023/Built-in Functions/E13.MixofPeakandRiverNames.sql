SELECT 
	p.[PeakName] AS peak
	,r.[RiverName] AS river
	,LOWER(CONCAT(p.[PeakName],SUBSTRING(r.[RiverName],2,LEN(r.[RiverName])-1))) AS Mix
FROM [Peaks] AS p, [Rivers] AS r
WHERE RIGHT(p.[PeakName],1) = LEFT(r.[RiverName],1)
ORDER BY Mix