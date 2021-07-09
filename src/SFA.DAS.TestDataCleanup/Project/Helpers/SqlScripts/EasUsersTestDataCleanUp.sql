PRINT CONCAT('Email - ', @email);
DECLARE @userId UNIQUEIDENTIFIER; select @userId = Id from dbo.[User] where email = @email;
PRINT CONCAT('UserId - ', @userId);
PRINT 'delete from UserSecurityCode'
delete from dbo.UserSecurityCode where UserId = @userId;
PRINT 'delete from UserPasswordHistory'
delete from dbo.UserPasswordHistory where UserId = @userId;
PRINT 'delete from [User]'
delete from dbo.[User] where email = @email;