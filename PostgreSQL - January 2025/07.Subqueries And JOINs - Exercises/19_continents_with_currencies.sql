 CREATE VIEW continent_currency_usage
AS
SELECT
	r.continent_code,
	r.currency_code,
	r.currency_usage
FROM
	(SELECT
		continent_code,
		currency_code,
		COUNT(*) AS currency_usage,
		DENSE_RANK() 
		OVER(PARTITION BY continent_code ORDER BY COUNT(*) DESC)
			AS currency_rank
	FROM
		countries
	GROUP BY
		continent_code, currency_code
	HAVING
		COUNT(*) > 1
	) AS r
WHERE
	r.currency_rank = 1
ORDER BY
	r.currency_usage DESC