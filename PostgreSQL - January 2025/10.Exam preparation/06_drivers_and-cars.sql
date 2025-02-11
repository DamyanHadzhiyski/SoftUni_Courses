SELECT
	d.first_name,
	d.last_name,
	c.make,
	c.model,
	c.mileage
FROM
	cars AS c
	JOIN cars_drivers AS cd ON cd.car_id = c.id
	JOIN drivers AS d ON d.id = cd.driver_id
WHERE
	c.mileage IS NOT NULL
ORDER BY
	c.mileage DESC, d.first_name
;