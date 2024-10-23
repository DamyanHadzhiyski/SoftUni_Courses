CREATE OR ALTER FUNCTION ufn_IsWordComprised (@setOfLetters VARCHAR(50), @word VARCHAR(50))
RETURNS BIT
AS
BEGIN
	DECLARE @i INT = 1

	WHILE @i <= LEN(@word)
		IF SUBSTRING(@word, @i, 1) LIKE '[' + @setOfLetters + ']'
			SET @i += 1
		ELSE
			RETURN 0
	RETURN 1
END