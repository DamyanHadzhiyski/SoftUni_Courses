SELECT
	mc.country_code,
	m.mountain_range,
	p.peak_name,
	p.elevation
FROM
	mountains AS m
	JOIN peaks AS p ON p.mountain_id = m.id
	JOIN mountains_countries AS mc USING(mountain_id)
WHERE
	p.elevation > 2835
		AND
	mc.country_code = 'BG'
ORDER BY
	p.elevation DESC