CREATE OR REPLACE FUNCTION 
	fn_count_employees_by_town(town_name VARCHAR(20))
RETURNS INT AS
$$
	DECLARE
		emp_count INT;
	BEGIN
		SELECT
			COUNT(*)
		FROM	
			employees AS e
			JOIN addresses AS a USING(address_id)
			JOIN towns As t USING(town_id)
		WHERE
			t.name = town_name INTO emp_count;
		RETURN emp_count;
	END
$$
LANGUAGE plpgsql;