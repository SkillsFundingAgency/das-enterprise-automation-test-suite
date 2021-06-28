Feature: PaymentValidation
	Test payment validation days in learning check
@ignore - test will fail until 90 days from start of phase 2 application date has elapsed
@employerincentivesPaymentsProcess
Scenario: Validation 90 Day check

Given an existing apprenticeship incentive
   When the Payment Run occurs
   Then the HasDaysInLearning Step in PendingPaymentValidationResult table is set to true
   Then the payment record for the first earnings is created