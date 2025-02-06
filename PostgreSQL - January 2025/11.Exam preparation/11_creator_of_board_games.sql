CREATE OR REPLACE FUNCTION
	fn_creator_with_board_games(searched_first_name VARCHAR(30))
RETURNS INT
AS
$$
	BEGIN
		RETURN 
			(SELECT
				COUNT(*)
			FROM
				creators AS c
				JOIN creators_board_games AS cbg ON cbg.creator_id = c.id
			WHERE
				c.first_name = searched_first_name);
	END;
$$
LANGUAGE plpgsql;