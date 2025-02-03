CREATE TABLE IF NOT EXISTS search_results (
    id SERIAL PRIMARY KEY,
    address_name VARCHAR(50),
    full_name VARCHAR(100),
    level_of_bill VARCHAR(20),
    make VARCHAR(30),
    condition CHAR(1),
    category_name VARCHAR(50)
);


CREATE OR REPLACE PROCEDURE 
	sp_courses_by_address(
		address_name VARCHAR(100)
	)
AS
$$
	BEGIN
		TRUNCATE TABLE search_results;

		INSERT INTO
			search_results(address_name, full_name, level_of_bill, make, condition, category_name)
		SELECT
				a.name AS address_name,
				c.full_name,
				(CASE
					WHEN cs.bill <= 20
						THEN 'Low'
					WHEN cs.bill <= 30
						THEN 'Medium'
					ELSE 'High'
				END) AS level_of_bill,
				cr.make,
				cr.condition,
				ct.name
			FROM
				courses AS cs
				JOIN clients AS c ON c.id = cs.client_id
				JOIN cars AS cr ON cr.id = cs.car_id
				JOIN addresses AS a ON a.id = cs.from_address_id
				JOIN categories AS ct ON ct.id = cr.category_id
			WHERE
				a.name = address_name
			ORDER BY
				cr.make, c.full_name;
	END;
$$
LANGUAGE plpgsql;