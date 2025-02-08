CREATE OR REPLACE FUNCTION
	udf_classification_items_count(classification_name VARCHAR(30))
RETURNS VARCHAR(30)
AS
$$
	DECLARE
		cnt INT;
		res VARCHAR(30);
	BEGIN
		
		SELECT
			COUNT(*) INTO cnt
		FROM
			classifications AS c
			JOIN items AS i ON i.classification_id = c.id
		WHERE
			c.name = classification_name;
			
		res := 'No items found.';
		
		IF cnt > 0 THEN
			res := CONCAT('Found ',cnt,' items.'); 
		END IF;

		RETURN res;
	END;
$$
LANGUAGE plpgsql;