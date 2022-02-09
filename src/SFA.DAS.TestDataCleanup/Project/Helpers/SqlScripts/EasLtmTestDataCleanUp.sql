select id into #applicationid from dbo.[Application] where EmployerAccountId in (select id from #accountids);
select id into #pledgeid from dbo.Pledge where EmployerAccountId in (select id from #accountids);

PRINT 'delete from ApplicationEmailAddress';
delete from ApplicationEmailAddress where ApplicationId in (select id from #applicationid);
PRINT 'delete from ApplicationStatusHistory';
delete from ApplicationStatusHistory where ApplicationId in (select id from #applicationid);
PRINT 'delete from ApplicationLocation';
delete from ApplicationLocation where ApplicationId in (select id from #applicationid);
PRINT 'delete from Application';
delete from [Application] where EmployerAccountId in (select id from #accountids);
PRINT 'delete from PledgeLocation';
delete from PledgeLocation where pledgeid in (select id from #pledgeid);
PRINT 'delete from Pledge';
delete from Pledge where EmployerAccountId in (select id from #accountids);
PRINT 'delete from Audit';
delete from [Audit] where entityId in (select id from #pledgeid);
PRINT 'delete from EmployerAccount';
delete from EmployerAccount where id in (select id from #accountids);