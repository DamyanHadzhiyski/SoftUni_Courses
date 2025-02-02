CREATE OR REPLACE FUNCTION 
	fn_difficulty_level(level INT)
RETURNS
	VARCHAR 
AS
$$
	DECLARE
		diff_level VARCHAR;
	BEGIN
		IF level <= 40 THEN
			diff_level := 'Normal Difficulty';
		ELSIF level BETWEEN 41 AND 60 THEN
			diff_level := 'Nightmare Difficulty';
		ELSE
			diff_level := 'Hell Difficulty';
		END IF;

		RETURN diff_level;
	END;
$$
LANGUAGE plpgsql;