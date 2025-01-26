SELECT
	e.employee_id,
	CONCAT(e.first_name, ' ', e.last_name) AS full_name,
	p.project_id,
	p.name
FROM
	employees AS e
	JOIN employees_projects AS ep ON ep.employee_id = e.employee_id
	JOIN projects AS p ON p.project_id = ep.project_id
WHERE
	ep.project_id = 1
ORDER BY
	e.employee_id
;