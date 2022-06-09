select id into #userIds from dbo.[User] where email in (select email from #emails);
PRINT 'delete from UserSecurityCode'
delete from dbo.UserSecurityCode where UserId in (select id from #userIds)
PRINT 'delete from UserPasswordHistory'
delete from dbo.UserPasswordHistory where UserId in (select id from #userIds)
PRINT 'delete from [User]'
delete from dbo.[User] where email in (select email from #emails);