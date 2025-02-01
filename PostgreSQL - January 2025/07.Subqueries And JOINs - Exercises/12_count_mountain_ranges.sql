SELECT
	mc.country_code,
	COUNT(*) AS mountain_range_count
FROM
	mountains_countries AS mc
WHERE
	mc.country_code IN ('BG', 'US', 'RU')
GROUP BY
	mc.country_code
ORDER BY
	mountain_range_count DESC
;