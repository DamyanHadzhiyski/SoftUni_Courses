CREATE TABLE IF NOT EXISTS passports
(
	id INT GENERATED ALWAYS AS IDENTITY (START WITH 100 INCREMENT BY 1) PRIMARY KEY,
	nationality VARCHAR(50)
)
;

INSERT INTO passports(nationality)
VALUES
	('N34FG21B'), 
	('K65LO4R7'),
	('ZE657QP2')
;

CREATE TABLE IF NOT EXISTS people
(
	id SERIAL PRIMARY KEY,
	first_name VARCHAR(50),
	salary DECIMAL(10,2),
	passport_id INT REFERENCES passports(id)
)
;

INSERT INTO people(first_name, salary, passport_id)
VALUES
	('Roberto', 43300.0000, 101),
	('Tom', 56100.0000, 102),
	('Yana', 60200.0000, 100)
;