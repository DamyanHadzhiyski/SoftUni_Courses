CREATE OR ALTER PROC usp_GetTownsStartingWith
	(@StartString NVARCHAR(10))
AS
(SELECT 
	[Name]
FROM [Towns]
WHERE LOWER(LEFT([Name],LEN(@StartString))) = LOWER(@StartString))