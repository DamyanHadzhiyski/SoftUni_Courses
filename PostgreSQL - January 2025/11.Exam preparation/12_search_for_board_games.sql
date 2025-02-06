CREATE TABLE IF NOT EXISTS search_results (
    id SERIAL PRIMARY KEY,
    name VARCHAR(50),
    release_year INT,
    rating FLOAT,
    category_name VARCHAR(50),
    publisher_name VARCHAR(50),
    min_players VARCHAR(50),
    max_players VARCHAR(50)
);

CREATE OR REPLACE PROCEDURE
	usp_search_by_category(category VARCHAR(50))
AS
$$
	BEGIN
		INSERT INTO
			search_results(
				    name,
				    release_year,
				    rating,
				    category_name,
				    publisher_name,
				    min_players,
				    max_players
				)
			SELECT
				bg.name,
				bg.release_year,
				bg.rating,
				c.name,
				p.name,
				CONCAT(pr.min_players, ' people'),
				CONCAT(pr.max_players, ' people') 
			FROM
				board_games AS bg
				JOIN categories AS c ON c.id = bg.category_id
				JOIN publishers AS p ON p.id = bg.publisher_id
				JOIN players_ranges AS pr ON pr.id = bg.players_range_id
			WHERE
				c.name = 'Wargames'
			ORDER BY
				p.name, bg.release_year DESC;
	END;
$$
LANGUAGE plpgsql;