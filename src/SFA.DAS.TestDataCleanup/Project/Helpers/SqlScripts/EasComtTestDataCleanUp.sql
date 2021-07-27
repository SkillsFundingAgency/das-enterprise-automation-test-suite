select id into #commitmentids from Commitment where EmployerAccountId in (select id from #accountids);
select id into #apprenticeshipids from Apprenticeship where CommitmentId in (select id from #commitmentids);

PRINT 'delete from History';
delete from dbo.History where CommitmentId in (select id from #commitmentids)
PRINT 'delete from Message';
delete from dbo.[Message] where CommitmentId in (select id from #commitmentids)
PRINT 'delete from BulkUpload';
delete from dbo.BulkUpload where CommitmentId in (select id from #commitmentids)
PRINT 'delete from CustomProviderPaymentPriority';
delete from dbo.CustomProviderPaymentPriority where EmployerAccountId in (select id from #accountids);
PRINT 'delete from ChangeOfPartyRequest';
delete from dbo.ChangeOfPartyRequest where ApprenticeshipId in (select id from #apprenticeshipids)
PRINT 'delete from PriceHistory';
delete from dbo.PriceHistory where ApprenticeshipId in (select id from #apprenticeshipids)
PRINT 'delete from Relationship';
delete from dbo.Relationship where EmployerAccountId in (select id from #accountids);
PRINT 'delete from TransferRequest';
delete from dbo.TransferRequest where CommitmentId in (select id from #commitmentids)
PRINT 'delete from DataLockStatus';
delete from dbo.DataLockStatus where ApprenticeshipId in (select id from #apprenticeshipids)
PRINT 'delete from ApprenticeshipUpdate';
delete from dbo.ApprenticeshipUpdate where ApprenticeshipId in (select id from #apprenticeshipids)
PRINT 'delete from ApprenticeshipConfirmationStatus';
delete from dbo.ApprenticeshipConfirmationStatus where ApprenticeshipId in (select id from #apprenticeshipids)
PRINT 'delete from Apprenticeship';
delete from dbo.Apprenticeship where CommitmentId in (select id from #commitmentids)
PRINT 'delete from Commitment';
delete from dbo.Commitment where EmployerAccountId in (select id from #accountids);
PRINT 'delete from AccountLegalEntities';
delete from dbo.AccountLegalEntities where AccountId in (select id from #accountids);
PRINT 'delete from Accounts';
delete from dbo.Accounts where Id in (select id from #accountids);