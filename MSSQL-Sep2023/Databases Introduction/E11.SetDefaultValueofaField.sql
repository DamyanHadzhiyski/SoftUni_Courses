ALTER TABLE [USERS]
ADD CONSTRAINT DF_LAST_LOGIN_TIME DEFAULT GETDATE() FOR [LASTLOGINTIME]