SELECT
	first_name,
	last_name,
	extract(YEAR FROM born) AS year
FROM authors
ORDER BY id;