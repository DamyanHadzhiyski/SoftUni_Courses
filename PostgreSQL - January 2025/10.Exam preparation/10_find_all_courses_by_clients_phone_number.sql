CREATE OR REPLACE FUNCTION 
	fn_courses_by_client(
		phone_num VARCHAR(20)
	)
RETURNS INT
AS
$$
	DECLARE
		res INT;
	BEGIN
		SELECT
			COUNT(*)
		FROM
			clients AS c
		JOIN courses AS cs ON cs.client_id = c.id
		WHERE
			c.phone_number = phone_num
		GROUP BY
			c.phone_number INTO res;

		IF res IS NULL THEN
			res = 0;
		END IF;

		RETURN res;
	END;
$$
LANGUAGE plpgsql;