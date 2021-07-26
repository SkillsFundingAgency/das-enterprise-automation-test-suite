select id into #comtids from dbo.Commitment where EmployerAccountId in (select id from #accountids);

PRINT 'delete from LevyDeclaration'
delete from dbo.LevyDeclaration where EmployerAccountId in (select id from #accountids);
PRINT 'delete from Balance'
delete from dbo.Balance where EmployerAccountId in (select id from #accountids);
PRINT 'delete from AccountProjection'
delete from dbo.AccountProjection where EmployerAccountId in (select id from #accountids);
PRINT 'delete from Payment'
delete from dbo.Payment where EmployerAccountId in (select id from #accountids) or SendingEmployerAccountId in (select id from #accountids);
PRINT 'delete from AccountProjectionCommitment'
delete from dbo.AccountProjectionCommitment where CommitmentId in (select id from #comtids)
PRINT 'delete from PaymentAggregation'
delete from dbo.PaymentAggregation where EmployerAccountId in (select id from #accountids);
PRINT 'delete from Commitment'
delete from dbo.Commitment where EmployerAccountId in (select id from #accountids) or SendingEmployerAccountId in (select id from #accountids);