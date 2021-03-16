 DELETE incentives.ClawbackPayment WHERE ApprenticeshipIncentiveId = @apprenticeshipIncentiveId;
 DELETE incentives.Payment WHERE ApprenticeshipIncentiveId = @apprenticeshipIncentiveId;
 
 DELETE x FROM incentives.PendingPaymentValidationResult x
	INNER JOIN incentives.PendingPayment pp ON pp.Id = PendingPaymentId
	WHERE ApprenticeshipIncentiveId = @apprenticeshipIncentiveId;

 DELETE incentives.PendingPayment WHERE ApprenticeshipIncentiveId = @apprenticeshipIncentiveId;

 DELETE x FROM incentives.LearningPeriod x INNER JOIN incentives.Learner l ON LearnerId=l.Id  WHERE ApprenticeshipIncentiveId = @apprenticeshipIncentiveId;

 DELETE x FROM incentives.ApprenticeshipDaysInLearning x INNER JOIN incentives.Learner l ON LearnerId=l.Id  WHERE ApprenticeshipIncentiveId = @apprenticeshipIncentiveId;

 DELETE incentives.Learner WHERE ApprenticeshipIncentiveId = @apprenticeshipIncentiveId;

 DELETE incentives.ApprenticeshipIncentive WHERE Id = @apprenticeshipIncentiveId;