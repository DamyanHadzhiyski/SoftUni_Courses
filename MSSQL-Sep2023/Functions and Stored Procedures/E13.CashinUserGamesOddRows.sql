CREATE OR ALTER FUNCTION ufn_CashInUsersGames(@gameName NVARCHAR(50))
RETURNS @result TABLE (SumCash DECIMAL(18,4))

AS

BEGIN

	INSERT INTO @result(SumCash)
	SELECT
		Sum(CASE WHEN r.[ROW_NUM] % 2 <> 0 THEN r.[Cash] END) AS SumCash
	FROM 
		(SELECT 
			ug.[Cash] AS [Cash]
			,g.[Name] AS [Name]
			,(ROW_NUMBER() OVER (PARTITION BY g.[Name] ORDER BY ug.[Cash] DESC)) AS ROW_NUM
		FROM [UsersGames] AS ug
			JOIN [Games] AS g ON g.Id = ug.GameId
			WHERE g.[Name] = @gameName) AS r				
	
	RETURN
END