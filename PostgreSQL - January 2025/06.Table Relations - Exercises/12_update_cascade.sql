ALTER TABLE countries_rivers
ADD CONSTRAINT fk_conuntries_rivers_countries 
	FOREIGN KEY (country_code) 
	REFERENCES countries(country_code)
	ON UPDATE CASCADE
;

ALTER TABLE countries_rivers
ADD CONSTRAINT fk_conuntries_rivers_rivers
	FOREIGN KEY (river_id) 
	REFERENCES rivers(id)
	ON UPDATE CASCADE
;