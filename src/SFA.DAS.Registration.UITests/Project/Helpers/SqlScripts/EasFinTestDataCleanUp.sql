PRINT CONCAT('AccountId - ', @accountid);
DECLARE @empref VARCHAR; select @empref = EmpRef from employer_financial.AccountPaye where AccountId = @accountid;
PRINT 'delete from TransactionLine' 
delete from employer_financial.TransactionLine where AccountId = @accountid;
PRINT 'delete from TransactionLine_EOF' 
delete from employer_financial.TransactionLine_EOF where AccountId = @accountid;
PRINT 'delete from Payment' 
delete from employer_financial.Payment where AccountId = @accountid;
PRINT 'delete from LevyDeclaration' 
delete from employer_financial.LevyDeclaration where AccountId = @accountid;
PRINT 'delete from LevyDeclarationNonUnique' 
delete from employer_financial.LevyDeclarationNonUnique where AccountId = @accountid;
PRINT 'delete from LevyDeclarationTopup'
delete from employer_financial.LevyDeclarationTopup where AccountId = @accountid;
PRINT 'delete from LevyOverride'
delete from employer_financial.LevyOverride where AccountId = @accountid;
PRINT 'delete from AccountTransfers'
delete from employer_financial.AccountTransfers where SenderAccountId = @accountid or ReceiverAccountId = @accountid;
PRINT 'delete from EnglishFraction'
delete from employer_financial.EnglishFraction where EmpRef = @empref;
PRINT 'delete from EnglishFractionOverride'
delete from employer_financial.EnglishFractionOverride where AccountId = @accountid;
PRINT 'delete from AccountPaye'
delete from employer_financial.AccountPaye where AccountId = @accountid;
PRINT 'delete from Account'
delete from employer_financial.Account where id = @accountid;
PRINT 'delete from AccountLegalEntity'
delete from employer_financial.AccountLegalEntity where AccountId = @accountid;