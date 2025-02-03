SELECT
	a.name AS address,
	(CASE
		WHEN EXTRACT('hour' FROM cs.start) BETWEEN 6 and 20
			THEN 'Day'
		ELSE 'Night' END) AS day_time,
	cs.bill,
	c.full_name,
	cr.make,
	cr.model,
	ct.name
FROM
	courses AS cs
	JOIN clients AS c ON c.id = cs.client_id
	JOIN cars AS cr ON cr.id = cs.car_id
	JOIN addresses AS a ON a.id = cs.from_address_id
	JOIN categories AS ct ON ct.id = cr.category_id
ORDER BY
	cs.id