SELECT
	COUNT(*)
FROM
	employees AS e
WHERE
	e.salary > (select AVG(salary) from employees)
;