SELECT
	c.full_name,
	COUNT(cs.car_id) AS count_of_cars,
	SUM(cs.bill) AS total_sum
FROM
	clients AS c
	JOIN courses AS cs ON cs.client_id = c.id
WHERE
	c.full_name LIKE '_a%'
GROUP BY
	c.full_name
HAVING
	COUNT(cs.car_id) > 1
ORDER BY
	c.full_name