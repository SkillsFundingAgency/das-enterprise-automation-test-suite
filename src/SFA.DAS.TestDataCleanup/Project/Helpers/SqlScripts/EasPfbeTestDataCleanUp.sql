select emailaddress into #emails from EmployerEmailDetails where AccountId in (select id from #accountids)
select FeedbackId into #feebackids from EmployerFeedback where AccountId in (select id from #accountids)
select UniqueSurveyCode into #surveycodes from EmployerSurveyCodes where FeedbackId in (select FeedbackId from #feebackids)

PRINT 'delete from staging_beta_users';
delete from staging_beta_users where EmailAddress in (select EmailAddress from #emails)
PRINT 'delete from staging_commitment';
delete from staging_commitment where EmployerAccountId in (select id from #accountids)
PRINT 'delete from staging_employer_accounts';
delete from staging_employer_accounts where AccountId in (select id from #accountids)
PRINT 'delete from EmployerSurveyHistory';
delete from EmployerSurveyHistory where UniqueSurveyCode in (select UniqueSurveyCode from #surveycodes)
PRINT 'delete from EmployerSurveyCodes';
delete from EmployerSurveyCodes where FeedbackId in (select FeedbackId from #feebackids)
PRINT 'delete from EmployerFeedback';
delete from EmployerFeedback where AccountId in (select id from #accountids)
PRINT 'delete from EmployerEmailDetails';
delete from EmployerEmailDetails  where AccountId in (select id from #accountids)
PRINT 'delete from Users';
delete from Users where EmailAddress in (select EmailAddress from #emails)