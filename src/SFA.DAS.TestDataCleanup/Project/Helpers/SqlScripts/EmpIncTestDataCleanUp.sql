PRINT CONCAT('Accountid - ', @accountid);
Declare @appincid uniqueidentifier; select @appincid = id from incentives.ApprenticeshipIncentive where AccountId = @accountid
PRINT CONCAT('AppIncId - ', @appincid);
Declare @pendingpaymentid UNIQUEIDENTIFIER; SELECT @pendingpaymentid = PendingPaymentId from incentives.Payment where ApprenticeshipIncentiveId = @appincid
PRINT CONCAT('PendingpaymentId - ', @pendingpaymentid);
Declare @leanerid UNIQUEIDENTIFIER; SELECT @leanerid = id from incentives.Learner where ApprenticeshipIncentiveId = @appincid
PRINT CONCAT('LearnerId - ', @leanerid);
PRINT 'delete from ClawbackPayment'
delete from incentives.ClawbackPayment where ApprenticeshipIncentiveId = @appincid
PRINT 'delete from ChangeOfCircumstance'
delete from incentives.ChangeOfCircumstance where ApprenticeshipIncentiveId = @appincid
PRINT 'delete from PendingPaymentValidationResult'
delete from incentives.PendingPaymentValidationResult where PendingPaymentId = @pendingpaymentid
PRINT 'delete from PendingPayment'
delete from incentives.PendingPayment where ApprenticeshipIncentiveId = @appincid or id = @pendingpaymentid
PRINT 'delete from Payment'
delete from incentives.Payment where ApprenticeshipIncentiveId = @appincid or PendingPaymentId = @pendingpaymentid
PRINT 'delete from ApprenticeshipBreakInLearning'
delete from incentives.ApprenticeshipBreakInLearning where ApprenticeshipIncentiveId = @appincid
PRINT 'delete from ApprenticeshipDaysInLearning'
delete from incentives.ApprenticeshipDaysInLearning where LearnerId = @leanerid
PRINT 'delete from LearningPeriod'
delete from incentives.LearningPeriod where LearnerId = @leanerid
PRINT 'delete from Learner'
delete from incentives.Learner where ApprenticeshipIncentiveId = @appincid
PRINT 'delete from ApprenticeshipIncentive'
delete from incentives.ApprenticeshipIncentive where AccountId = @accountid