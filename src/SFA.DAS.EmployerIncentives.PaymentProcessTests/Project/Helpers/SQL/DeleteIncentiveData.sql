DECLARE @apprenticeshipIncentiveId UNIQUEIDENTIFIER
DECLARE @apprenticeshipIncentiveIds TABLE (Id UNIQUEIDENTIFIER)
INSERT INTO @apprenticeshipIncentiveIds SELECT Id FROM incentives.ApprenticeshipIncentive WHERE AccountId=@accountId AND ApprenticeshipId=@apprenticeshipId
 
WHILE EXISTS (SELECT 1 FROM @apprenticeshipIncentiveIds)
BEGIN
    SET @apprenticeshipIncentiveId = (SELECT TOP 1 Id FROM @apprenticeshipIncentiveIds)
    DELETE incentives.ClawbackPayment WHERE ApprenticeshipIncentiveId = @apprenticeshipIncentiveId;
    DELETE archive.Payment WHERE ApprenticeshipIncentiveId = @apprenticeshipIncentiveId;
    DELETE incentives.Payment WHERE ApprenticeshipIncentiveId = @apprenticeshipIncentiveId;
 
    DELETE x FROM archive.PendingPaymentValidationResult x
        INNER JOIN archive.PendingPayment pp ON pp.PendingPaymentId = x.PendingPaymentId
        WHERE ApprenticeshipIncentiveId = @apprenticeshipIncentiveId;

    DELETE x FROM incentives.PendingPaymentValidationResult x
    INNER JOIN incentives.PendingPayment pp ON pp.Id = PendingPaymentId
    WHERE ApprenticeshipIncentiveId = @apprenticeshipIncentiveId;

    DELETE archive.PendingPayment WHERE ApprenticeshipIncentiveId = @apprenticeshipIncentiveId;
    DELETE incentives.PendingPayment WHERE ApprenticeshipIncentiveId = @apprenticeshipIncentiveId;

    DELETE x FROM incentives.LearningPeriod x INNER JOIN incentives.Learner l ON LearnerId=l.Id  WHERE ApprenticeshipIncentiveId = @apprenticeshipIncentiveId;

    DELETE x FROM incentives.ApprenticeshipDaysInLearning x INNER JOIN incentives.Learner l ON LearnerId=l.Id  WHERE ApprenticeshipIncentiveId = @apprenticeshipIncentiveId;

    DELETE incentives.ApprenticeshipBreakInLearning WHERE ApprenticeshipIncentiveId = @apprenticeshipIncentiveId;

    DELETE incentives.Learner WHERE ApprenticeshipIncentiveId = @apprenticeshipIncentiveId;

    DELETE incentives.ChangeOfCircumstance WHERE ApprenticeshipIncentiveId = @apprenticeshipIncentiveId;

    DELETE incentives.EmploymentCheck WHERE ApprenticeshipIncentiveId = @apprenticeshipIncentiveId;

    /* DELETE from the Main incentive table */
    DELETE incentives.ApprenticeshipIncentive WHERE Id = @apprenticeshipIncentiveId;

    DELETE @apprenticeshipIncentiveIds WHERE Id=@apprenticeshipIncentiveId
END

