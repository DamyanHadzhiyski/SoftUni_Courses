CREATE OR ALTER PROC usp_TransferMoney(@SenderId INT, @ReceiverId INT, @MoneyAmount DECIMAL(18,4))
AS
BEGIN TRANSACTION

		UPDATE [Accounts]
		SET [Balance] = [Balance] - @MoneyAmount
		WHERE [Id] = @SenderId

		UPDATE [Accounts]
		SET [Balance] = [Balance] + @MoneyAmount
		WHERE [Id] = @ReceiverId

		IF @MoneyAmount < 0
		BEGIN
			ROLLBACK;
			THROW 50001, 'Amount cannot be negative', 1
			RETURN
		END

COMMIT