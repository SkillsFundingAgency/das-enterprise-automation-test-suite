PRINT CONCAT('Email - ', @email);
DECLARE @emailvar VARCHAR(255); set @emailvar = @email;
PRINT 'delete from Invitations';select * from Invitations where EmployerEmail = @emailvar;
PRINT 'delete from Unsubscribed';select * from Unsubscribed where EmailAddress = @emailvar;