select id into #incentiveapplicationids from dbo.IncentiveApplication where AccountId in (select id from #accountids)
select id into #incentiveapplicationapprenticeshipids from dbo.IncentiveApplicationApprenticeship where IncentiveApplicationId in (select id from #incentiveapplicationids)

select id into #apprenticeshipincentiveids from incentives.ApprenticeshipIncentive where AccountId in (select id from #accountids)
select id into #pendingpaymentids from incentives.PendingPayment where AccountId in (select id from #accountids)
select id into #leanerids from incentives.Learner where ApprenticeshipIncentiveId in (select id from #apprenticeshipincentiveids)

PRINT 'delete from ClawbackPayment'
delete from incentives.ClawbackPayment where AccountId in (select id from #accountids)
PRINT 'delete from ChangeOfCircumstance'
delete from incentives.ChangeOfCircumstance where ApprenticeshipIncentiveId in (select id from #apprenticeshipincentiveids)
PRINT 'delete from PendingPaymentValidationResult'
delete from incentives.PendingPaymentValidationResult where PendingPaymentId in (select id from #pendingpaymentids)
PRINT 'delete from PendingPayment'
delete from incentives.PendingPayment where AccountId in (select id from #accountids)
PRINT 'delete from Payment'
delete from incentives.Payment where AccountId in (select id from #accountids)
PRINT 'delete from ApprenticeshipBreakInLearning'
delete from incentives.ApprenticeshipBreakInLearning where ApprenticeshipIncentiveId in (select id from #apprenticeshipincentiveids)
PRINT 'delete from ApprenticeshipDaysInLearning'
delete from incentives.ApprenticeshipDaysInLearning where LearnerId in (select id from #leanerids)
PRINT 'delete from LearningPeriod'
delete from incentives.LearningPeriod where LearnerId in (select id from #leanerids)
PRINT 'delete from Learner'
delete from incentives.Learner where ApprenticeshipIncentiveId in (select id from #apprenticeshipincentiveids)
PRINT 'delete from IncentiveApplicationStatusAudit'
delete from dbo.IncentiveApplicationStatusAudit where IncentiveApplicationApprenticeshipId in (select id from #incentiveapplicationapprenticeshipids)
PRINT 'delete from IncentiveApplicationApprenticeship'
delete from dbo.IncentiveApplicationApprenticeship where IncentiveApplicationId in (select id from #incentiveapplicationids)
PRINT 'delete from IncentiveApplication'
delete from dbo.IncentiveApplication where AccountId in (select id from #accountids)
PRINT 'delete from ApprenticeshipIncentive'
delete from incentives.ApprenticeshipIncentive where AccountId in (select id from #accountids)
PRINT 'delete from Accounts'
delete from dbo.Accounts where id in (select id from #accountids)
