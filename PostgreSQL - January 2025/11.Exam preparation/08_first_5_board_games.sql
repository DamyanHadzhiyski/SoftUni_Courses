SELECT
	bg.name,
	bg.rating,
	c.name AS category_name
FROM
	board_games AS bg
	JOIN players_ranges AS pr ON pr.id = bg.players_range_id
	JOIN categories AS c ON c.id = bg.category_id
WHERE
	(bg.rating > 7 AND (lower(bg.name) LIKE '%a%' OR bg.rating > 7.5) 
		AND 
	(pr.min_players >= 2 AND pr.max_players <= 5))
ORDER BY
	bg.name, bg.rating DESC
LIMIT 5
;