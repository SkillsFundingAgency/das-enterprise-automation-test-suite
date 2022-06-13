PRINT 'delete from Invitations';
delete from Invitations where EmployerEmail in (select email from #emails);
PRINT 'delete from Unsubscribed';
delete from Unsubscribed where EmailAddress in (select email from #emails);