CREATE OR REPLACE PROCEDURE 
	sp_animals_with_owners_or_not(
		IN animal_name VARCHAR(30),
		OUT return_val VARCHAR
	)
AS
$$
	BEGIN	
		SELECT
			COALESCE(o.name, 'For adoption') INTO return_val
		FROM
			animals AS a
			LEFT JOIN owners AS o ON o.id = a.owner_id 
		WHERE
			a.name = animal_name;
	END;
$$
LANGUAGE plpgsql;