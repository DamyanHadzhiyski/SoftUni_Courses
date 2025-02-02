CREATE OR REPLACE FUNCTION 
	fn_full_name(first_name VARCHAR, last_name VARCHAR)
RETURNS 
	VARCHAR
AS
$$
	DECLARE
		full_name VARCHAR;
	BEGIN
		IF last_name IS NULL THEN
			full_name := INITCAP(first_name);
		ELSIF first_name IS NULL THEN
			full_name := INITCAP(last_name);
		ELSE
			full_name := CONCAT(INITCAP(first_name), ' ', INITCAP(last_name));
		END IF;

		RETURN
			full_name;
	END
$$
LANGUAGE plpgsql;