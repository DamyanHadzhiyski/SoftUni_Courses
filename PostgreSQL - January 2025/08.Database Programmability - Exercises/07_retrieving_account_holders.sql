CREATE OR REPLACE PROCEDURE 
	sp_retrieving_holders_with_balance_higher_than(
		searched_balance NUMERIC
	)
AS
$$
	DECLARE
		res RECORD;
	BEGIN
		FOR res IN 
                SELECT 
					ah.first_name, 
					ah.last_name,
					SUM(balance) AS total_balance
				FROM
					accounts AS a
					JOIN account_holders AS ah ON ah.id = a.account_holder_id
				GROUP BY
					ah.first_name, ah.last_name
				HAVING
					SUM(balance) > searched_balance
				ORDER BY
					ah.first_name, ah.last_name LOOP
			RAISE NOTICE '% % - %', res.first_name, res.last_name, res.total_balance;
		END LOOP;
	END;
$$
LANGUAGE plpgsql;