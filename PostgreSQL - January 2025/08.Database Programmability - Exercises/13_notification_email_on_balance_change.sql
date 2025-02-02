CREATE TABLE IF NOT EXISTS
	notifications_emails(
		id INT GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
		recepient_id INT,
		subject VARCHAR,
		body VARCHAR
	)
;

CREATE OR REPLACE FUNCTION 
	trigger_fn_send_email_on_balance_change()
RETURNS TRIGGER
AS
$$
	BEGIN
		INSERT INTO
			notification_emails(recepient_id, subject, body)
		VALUES
			(old.account_id, 
			'Balance change for account: ' || old.account_id, 
			CONCAT_WS(' ','On',NOW()::DATE,
					'your balance was changed from',
					old.balance,'to',new.balance));
		RETURN new;
	END
$$
LANGUAGE plpgsql;

CREATE TRIGGER tr_send_email_on_balance_change
AFTER UPDATE OF new_sum ON logs
FOR EACH ROW
WHEN 
    (new.new_sum <> old.new_sum)
	EXECUTE FUNCTION trigger_fn_send_email_on_balance_change();