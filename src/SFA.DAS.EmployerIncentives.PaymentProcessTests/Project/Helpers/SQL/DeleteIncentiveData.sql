 DECLARE @ApprenticeshipIncentiveId UNIQUEIDENTIFIER
 SET @ApprenticeshipIncentiveId=(SELECT Id FROM incentives.ApprenticeshipIncentive WHERE AccountId=@accountId AND ApprenticeshipId=@apprenticeshipId)
 
 DELETE incentives.ClawbackPayment WHERE ApprenticeshipIncentiveId = @ApprenticeshipIncentiveId;
 DELETE archive.Payment WHERE ApprenticeshipIncentiveId = @ApprenticeshipIncentiveId;
 DELETE incentives.Payment WHERE ApprenticeshipIncentiveId = @ApprenticeshipIncentiveId;
 
DELETE x FROM archive.PendingPaymentValidationResult x
	INNER JOIN archive.PendingPayment pp ON pp.PendingPaymentId = x.PendingPaymentId
	WHERE ApprenticeshipIncentiveId = @ApprenticeshipIncentiveId;

 DELETE x FROM incentives.PendingPaymentValidationResult x
	INNER JOIN incentives.PendingPayment pp ON pp.Id = PendingPaymentId
	WHERE ApprenticeshipIncentiveId = @ApprenticeshipIncentiveId;

 DELETE archive.PendingPayment WHERE ApprenticeshipIncentiveId = @ApprenticeshipIncentiveId;
 DELETE incentives.PendingPayment WHERE ApprenticeshipIncentiveId = @ApprenticeshipIncentiveId;

 DELETE x FROM incentives.LearningPeriod x INNER JOIN incentives.Learner l ON LearnerId=l.Id  WHERE ApprenticeshipIncentiveId = @ApprenticeshipIncentiveId;

 DELETE x FROM incentives.ApprenticeshipDaysInLearning x INNER JOIN incentives.Learner l ON LearnerId=l.Id  WHERE ApprenticeshipIncentiveId = @ApprenticeshipIncentiveId;

 DELETE incentives.ApprenticeshipBreakInLearning WHERE ApprenticeshipIncentiveId = @ApprenticeshipIncentiveId;

 DELETE incentives.Learner WHERE ApprenticeshipIncentiveId = @ApprenticeshipIncentiveId;

 DELETE incentives.ChangeOfCircumstance WHERE ApprenticeshipIncentiveId = @ApprenticeshipIncentiveId;

 
 /* DELETE from the Main incentive table */
 DELETE incentives.ApprenticeshipIncentive WHERE Id = @ApprenticeshipIncentiveId;

