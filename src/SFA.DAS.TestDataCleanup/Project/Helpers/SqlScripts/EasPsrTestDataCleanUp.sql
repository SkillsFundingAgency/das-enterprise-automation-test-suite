select id into #reportids from Report where EmployerId in (select id from #accounthashedids)
PRINT 'delete from AuditHistory';
delete from dbo.AuditHistory where ReportId in (select id from #reportids);
PRINT 'delete from Log';
delete from dbo.Log where ReportId in (select id from #reportids);
PRINT 'delete from Report';
delete from dbo.Report where EmployerId in (select id from #accounthashedids);
