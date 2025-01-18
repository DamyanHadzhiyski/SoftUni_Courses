SELECT
	department_id,
	AVG(salary) AS min_salary
FROM
	employees
GROUP BY
	department_id
ORDER BY
	department_id
;