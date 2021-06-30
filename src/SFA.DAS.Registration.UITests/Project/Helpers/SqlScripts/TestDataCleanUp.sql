PRINT CONCAT('Email - ', @email);
DECLARE @userid int; select @userid = id from employer_account.[User] where email = @email;
PRINT CONCAT('UserId - ', @userid);
DECLARE @accountid int; select @accountid = AccountId from employer_account.Membership where UserId = @userid;
PRINT CONCAT('AccountId - ', @accountid);
DECLARE @accountlegalentityid int; select @accountlegalentityid = id from employer_account.AccountLegalEntity where AccountId = @accountid;
PRINT CONCAT('Accountlegalentityid - ', @accountlegalentityid);
PRINT 'delete from Invitation' 
delete from employer_account.Invitation where AccountId = @accountid;
PRINT 'delete from UserAornFailedAttempts'
delete from employer_account.UserAornFailedAttempts where UserId = @userid;
PRINT 'delete from AccountHistoryNonUnique'
delete from employer_account.AccountHistoryNonUnique where AccountId = @accountid;
PRINT 'delete from EmployerAgreement_Backup'
delete from employer_account.EmployerAgreement_Backup where AccountId = @accountid;
PRINT 'delete from EmployerAgreement'
delete from employer_account.EmployerAgreement where AccountLegalEntityId = @accountlegalentityid or SignedById = @userid;
PRINT 'delete from AccountHistory'
delete from employer_account.AccountHistory where AccountId = @accountid;
PRINT 'delete from Paye'
delete from employer_account.Paye where Ref in ( select EmpRef from employer_account.GetAccountPayeSchemes where AccountId = @accountid);
PRINT 'delete from TransferConnectionInvitation'
delete from employer_account.TransferConnectionInvitation where SenderAccountId = @accountid or ReceiverAccountId = @accountid;
PRINT 'delete from TransferConnectionInvitationChange'
delete from employer_account.TransferConnectionInvitationChange where SenderAccountId = @accountid or ReceiverAccountId = @accountid or UserId = @userid;
PRINT 'delete from TransferRequest'
delete from employer_account.TransferRequest where SenderAccountId = @accountid or ReceiverAccountId = @accountid;
PRINT 'delete from UserAccountSettings'
delete from employer_account.UserAccountSettings where AccountId = @accountid or UserId = @userid;
PRINT 'delete from UserAornFailedAttempts'
delete from employer_account.UserAornFailedAttempts where UserId = @userid;
PRINT 'delete from AccountLegalEntity'
delete from employer_account.AccountLegalEntity where AccountId = @accountid;
PRINT 'delete from Membership'
delete from employer_account.Membership where UserId = @userid;
PRINT 'delete from Account'
delete from employer_account.Account where id = @accountid;
PRINT 'delete from User'
delete from employer_account.[User] where id = @userid;
