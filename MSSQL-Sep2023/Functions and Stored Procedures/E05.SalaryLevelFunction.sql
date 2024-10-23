CREATE OR ALTER FUNCTION ufn_GetSalaryLevel(@salary DECIMAL(18,4))
RETURNS VARCHAR(10)
AS
BEGIN
	DECLARE @result VARCHAR(10)
	IF @salary < 30000
		SET @result = 'Low'
	ELSE IF @salary BETWEEN 30000 AND 50000
		SET @result = 'Average'
	ELSE
		SET @result = 'High'

	RETURN @result
END