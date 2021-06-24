USE [SFA.DAS.EmployerIncentives.Database]
GO
SET QUOTED_IDENTIFIER ON
GO

DELETE [dbo].[ClientOutboxData]
DELETE [dbo].[OutboxData]

DELETE incentives.ClawbackPayment
DELETE archive.Payment
DELETE archive.PendingPaymentValidationResult
DELETE archive.PendingPayment

DELETE incentives.Payment
DELETE incentives.PendingPaymentValidationResult
DELETE incentives.PendingPayment
DELETE incentives.LearningPeriod
DELETE incentives.ApprenticeshipDaysInLearning
DELETE incentives.ApprenticeshipBreakInLearning
DELETE incentives.Learner
DELETE incentives.ApprenticeshipIncentive