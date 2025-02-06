SELECT
	g.id,
	g.name,
	g.release_year,
	c.name AS category_name

FROM
	board_games AS g
	JOIN categories AS c ON c.id = g.category_id
WHERE
	c.name = 'Strategy Games'
		OR
	c.name = 'Wargames'
ORDER BY
	release_year DESC
;