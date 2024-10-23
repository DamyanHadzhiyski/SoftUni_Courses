CREATE PROC usp_GetHoldersFullName
AS
(
	SELECT
		CONCAT_WS(' ',ah.[FirstName], ah.[LastName])
	FROM [AccountHolders] ah
)