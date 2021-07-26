PRINT CONCAT('Email - ', @email);
DECLARE @emailvar VARCHAR(255); set @emailvar = @email;
PRINT 'delete from Invitations';
delete from Invitations where EmployerEmail = @emailvar;
PRINT 'delete from Unsubscribed';
delete from Unsubscribed where EmailAddress = @emailvar;