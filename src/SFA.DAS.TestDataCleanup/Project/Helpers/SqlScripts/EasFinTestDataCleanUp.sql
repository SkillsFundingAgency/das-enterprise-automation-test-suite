select EmpRef into #emprefs from employer_financial.AccountPaye where AccountId in (select id from #accountids);

PRINT 'delete from TransactionLine' 
delete from employer_financial.TransactionLine where AccountId in (select id from #accountids);
PRINT 'delete from TransactionLine_EOF' 
delete from employer_financial.TransactionLine_EOF where AccountId in (select id from #accountids);
PRINT 'delete from Payment' 
delete from employer_financial.Payment where AccountId in (select id from #accountids);
PRINT 'delete from LevyDeclaration' 
delete from employer_financial.LevyDeclaration where AccountId in (select id from #accountids);
PRINT 'delete from LevyDeclarationNonUnique' 
delete from employer_financial.LevyDeclarationNonUnique where AccountId in (select id from #accountids);
PRINT 'delete from LevyDeclarationTopup'
delete from employer_financial.LevyDeclarationTopup where AccountId in (select id from #accountids);
PRINT 'delete from LevyOverride'
delete from employer_financial.LevyOverride where AccountId in (select id from #accountids);
PRINT 'delete from AccountTransfers'
delete from employer_financial.AccountTransfers where SenderAccountId in (select id from #accountids) or ReceiverAccountId in (select id from #accountids);
PRINT 'delete from EnglishFraction'
delete from employer_financial.EnglishFraction where EmpRef in (select EmpRef from #emprefs);
PRINT 'delete from EnglishFractionOverride'
delete from employer_financial.EnglishFractionOverride where AccountId in (select id from #accountids);
PRINT 'delete from AccountPaye'
delete from employer_financial.AccountPaye where AccountId in (select id from #accountids);
PRINT 'delete from Account'
delete from employer_financial.Account where id in (select id from #accountids);
PRINT 'delete from AccountLegalEntity'
delete from employer_financial.AccountLegalEntity where AccountId in (select id from #accountids);