SELECT
	c.id AS car_id,
	c.make,
	c.mileage,
	COUNT(cs.id) AS count_of_courses,
	ROUND(AVG(cs.bill),2) AS average_bill
FROM
	cars AS c
	LEFT JOIN courses AS cs ON cs.car_id = c.id
GROUP BY 
	c.id, c.make, c.mileage
HAVING
	COUNT(*) <> 2
ORDER BY
	count_of_courses DESC, c.id
;