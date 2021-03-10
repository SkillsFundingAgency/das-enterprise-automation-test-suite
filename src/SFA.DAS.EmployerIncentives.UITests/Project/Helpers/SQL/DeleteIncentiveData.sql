 DELETE incentives.ClawbackPayment WHERE ApprenticeshipIncentiveId = '@ApprenticeshipIncentiveId';
 DELETE incentives.Payment WHERE ApprenticeshipIncentiveId = '@ApprenticeshipIncentiveId';
 
 DELETE x FROM incentives.PendingPaymentValidationResult x
	INNER JOIN incentives.PendingPayment pp ON pp.Id = PendingPaymentId
	WHERE ApprenticeshipIncentiveId = '@ApprenticeshipIncentiveId';

 DELETE incentives.PendingPayment WHERE ApprenticeshipIncentiveId = '@ApprenticeshipIncentiveId';

 DELETE x FROM incentives.LearningPeriod x INNER JOIN incentives.Learner l ON LearnerId=l.Id  WHERE ApprenticeshipIncentiveId = '@ApprenticeshipIncentiveId';

 DELETE x FROM incentives.ApprenticeshipDaysInLearning x INNER JOIN incentives.Learner l ON LearnerId=l.Id  WHERE ApprenticeshipIncentiveId = '@ApprenticeshipIncentiveId';

 DELETE incentives.Learner WHERE ApprenticeshipIncentiveId = '@ApprenticeshipIncentiveId';

 DELETE incentives.ApprenticeshipIncentive WHERE Id = '@ApprenticeshipIncentiveId';