CREATE OR REPLACE PROCEDURE 
	sp_withdraw_money(account_id INT, money_amount DECIMAL(10,4))
AS
$$
	DECLARE
		init_amount DECIMAL;
	BEGIN
		SELECT balance FROM accounts WHERE id = account_id INTO init_amount;

		IF init_amount < money_amount THEN
			RAISE NOTICE 'Insufficient balance to withdraw %', money_amount;
			RETURN;
		END IF;
		
		UPDATE
			accounts
		SET
			balance = balance - money_amount
		WHERE
			id = account_id;
	END;
$$
LANGUAGE plpgsql;