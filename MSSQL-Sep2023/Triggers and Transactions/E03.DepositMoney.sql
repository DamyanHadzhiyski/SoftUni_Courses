CREATE OR ALTER PROC usp_DepositMoney(@AccountId INT, @MoneyAmount DECIMAL(18,4))
AS
	BEGIN TRANSACTION
		
		UPDATE [Accounts]
		SET [Balance] = [Balance] + @MoneyAmount
		WHERE [Id] = @AccountId

		IF @MoneyAmount < 0
		BEGIN
			ROLLBACK;
			THROW 50001, 'Amount cannot be negative', 1
			RETURN
		END

	COMMIT
GO