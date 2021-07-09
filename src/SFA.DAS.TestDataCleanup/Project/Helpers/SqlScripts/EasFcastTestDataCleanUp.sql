PRINT CONCAT('Accountid - ', @accountid);
DECLARE @commtid int; select @commtid = id from dbo.Commitment where EmployerAccountId = @accountid;
PRINT 'delete from LevyDeclaration'
delete from dbo.LevyDeclaration where EmployerAccountId = @accountid
PRINT 'delete from Balance'
delete from dbo.Balance where EmployerAccountId = @accountid
PRINT 'delete from AccountProjection'
delete from dbo.AccountProjection where EmployerAccountId = @accountid
PRINT 'delete from Payment'
delete from dbo.Payment where EmployerAccountId = @accountid or SendingEmployerAccountId = @accountid
PRINT 'delete from AccountProjectionCommitment'
delete from dbo.AccountProjectionCommitment where CommitmentId = @commtid
PRINT 'delete from PaymentAggregation'
delete from dbo.PaymentAggregation where EmployerAccountId = @accountid
PRINT 'delete from Commitment'
delete from dbo.Commitment where EmployerAccountId = @accountid or SendingEmployerAccountId = @accountid