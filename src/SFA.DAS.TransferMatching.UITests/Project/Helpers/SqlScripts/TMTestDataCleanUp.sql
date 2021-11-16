DECLARE @amountvar int; set @amountvar = @amount;
DECLARE @createdonvar datetime; set @createdonvar = @createdon;

if (select count(*) from Pledge where EmployerAccountId in (__EmployerAccountId__) and Amount = @amountvar and CreatedOn < GETDATE() and CreatedOn >= @createdonvar) = 1 
Begin 
DECLARE @pledgeid int, @applicationid int; 

select @pledgeid = Id from Pledge where EmployerAccountId in (__EmployerAccountId__) and Amount = @amountvar and CreatedOn < GETDATE() and CreatedOn >= @createdonvar
select @applicationid = Id from [Application] WHERE PledgeId = @pledgeid

delete from ApplicationEmailAddress where ApplicationId = @applicationid;
delete from ApplicationStatusHistory where ApplicationId = @applicationid;
delete from ApplicationLocation where ApplicationId = @applicationid;
delete from [Application] WHERE PledgeId = @pledgeid;
delete from [PledgeLocation] WHERE PledgeId = @pledgeid;
delete from [Pledge] where id = @pledgeid;

End
