SELECT
	COUNT(*)
FROM
	countries AS c
	LEFT JOIN countries_rivers AS cr ON cr.country_code = c.country_code
WHERE
	cr.country_code IS NULL
;