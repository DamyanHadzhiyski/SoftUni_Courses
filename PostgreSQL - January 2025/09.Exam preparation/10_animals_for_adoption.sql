SELECT
	a.name AS animal,
	DATE_PART('YEAR', a.birthdate) AS birth_year,
	at.animal_type
FROM
	animals AS a
	LEFT JOIN owners AS o ON a.owner_id = o.id
	JOIN animal_types AS at ON at.id = a.animal_type_id
WHERE
	(date '2022-01-01' - INTERVAL '5 years' < a.birthdate)
		AND
	(a.owner_id IS NULL)
		AND
	(at.animal_type <> 'Birds')
ORDER BY
	a.name
;