PRINT CONCAT('Accountid - ', @accountid);
PRINT 'delete from Reservation'
delete from dbo.Reservation where AccountId = @accountid
PRINT 'delete from ProviderPermission'
delete from dbo.ProviderPermission where AccountId = @accountid
PRINT 'delete from AccountLegalEntity'
delete from dbo.AccountLegalEntity where AccountId = @accountid
PRINT 'delete from Account'
delete from Account where id = @accountid