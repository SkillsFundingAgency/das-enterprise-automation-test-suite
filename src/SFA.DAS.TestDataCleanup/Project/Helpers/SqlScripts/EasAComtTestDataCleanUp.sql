select email into #apprenticeemails from dbo.Registration where commitmentsapprenticeshipid in (select id from #commitmentsapprenticeshipid)
select id into #apprenticeid from dbo.Apprentice where email in (select email from #apprenticeemails)

PRINT 'delete from Revision';
Delete from dbo.Revision where commitmentsapprenticeshipid in (select id from #commitmentsapprenticeshipid);
PRINT 'delete from ApprenticeshipMatchAttempt';
Delete from dbo.ApprenticeshipMatchAttempt where Apprenticeid in (select id from #apprenticeid);
PRINT 'delete from ApprenticeEmailAddressHistory';
Delete from dbo.ApprenticeEmailAddressHistory where Apprenticeid in (select id from #apprenticeid);
PRINT 'delete from Apprenticeship';
Delete from dbo.Apprenticeship where Apprenticeid in (select id from #apprenticeid);
PRINT 'delete from Apprentice';
Delete from dbo.Apprentice where id in (select id from #apprenticeid);
PRINT 'delete from Registration';
Delete from dbo.Registration where commitmentsapprenticeshipid in (select id from #commitmentsapprenticeshipid);