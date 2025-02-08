SELECT
	c.id AS customer_id,
	CONCAT(c.first_name,' ', c.last_name) AS full_name,
	COUNT(o.id) AS total_orders,
	(CASE c.loyalty_card
		WHEN true THEN
			'Loyal Customer'
		ELSE
			'Regular Customer'
	END) AS loyalty_status
FROM
	customers AS c
	JOIN orders AS o ON o.customer_id = c.id
	LEFT JOIN reviews AS r ON r.customer_id = c.id
WHERE
	r.item_id IS NULL
GROUP BY
	c.id, full_name
HAVING
	COUNT(o.id) >= 1 
ORDER BY
	total_orders DESC, c.id