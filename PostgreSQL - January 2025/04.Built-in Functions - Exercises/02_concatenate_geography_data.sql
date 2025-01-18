CREATE VIEW view_continents_countries_currencies_details
AS
SELECT
	CONCAT_WS(': ', c.continent_name, c.continent_code)
		AS continent_details,
	CONCAT_WS(' - ', cn.country_name, cn.capital, cn.area_in_sq_km, 'km2')
		AS country_information,
	CONCAT(' ', cu.description, ' (',cu.currency_code,')')
		AS currencies
FROM 
	continents AS c
	JOIN countries AS cn ON cn.continent_code = c.continent_code
	JOIN currencies AS cu ON cu.currency_code = cn.currency_code
ORDER BY 
	country_information, currencies;