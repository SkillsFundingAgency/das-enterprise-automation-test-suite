select id into #appIds from dbo.[Apprentice] where email in (select email from #emails);
PRINT 'delete from MyApprenticeship'
delete from dbo.MyApprenticeship where apprenticeid in (select id from #appIds)
PRINT 'delete from ApprenticePreferences'
delete from dbo.ApprenticePreferences where apprenticeid in (select id from #appIds)
PRINT 'delete from ApprenticeEmailAddressHistory'
delete from dbo.ApprenticeEmailAddressHistory where EmailAddress in (select email from #emails);
PRINT 'delete from Apprentice'
delete from dbo.Apprentice where id in (select id from #appIds)