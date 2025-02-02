CREATE OR REPLACE FUNCTION 
	fn_cash_in_users_games(game_name VARCHAR(50))
RETURNS
	TABLE(total_cash NUMERIC)
AS
$$
	DECLARE
		game_id_res INT;
	BEGIN
		SELECT id FROM games WHERE name = game_name INTO game_id_res;
		
		RETURN QUERY(
			SELECT
				ROUND(SUM(r.cash),2)
			FROM
				(SELECT
					cash,
					ROW_NUMBER() OVER(ORDER BY cash DESC) AS row_num
				FROM
					users_games
				WHERE
					game_id = game_id_res) AS r
			WHERE
				r.row_num % 2 != 0
		);
	END;
$$
LANGUAGE plpgsql;