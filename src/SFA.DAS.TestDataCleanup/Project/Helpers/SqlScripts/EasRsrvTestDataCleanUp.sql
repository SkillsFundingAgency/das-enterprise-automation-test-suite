PRINT 'delete from Reservation'
delete from dbo.Reservation where AccountId in (select id from #accountids)
PRINT 'delete from ProviderPermission'
delete from dbo.ProviderPermission where AccountId in (select id from #accountids)
PRINT 'delete from AccountLegalEntity'
delete from dbo.AccountLegalEntity where AccountId in (select id from #accountids)
PRINT 'delete from Account'
delete from Account where id in (select id from #accountids)