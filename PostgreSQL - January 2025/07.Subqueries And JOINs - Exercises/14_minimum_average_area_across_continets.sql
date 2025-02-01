SELECT
	MIN(r.area) AS min_average_area
FROM
		(SELECT
			AVG(c.area_in_sq_km) AS area
		FROM
			countries AS c
		GROUP BY
			c.continent_code) AS r