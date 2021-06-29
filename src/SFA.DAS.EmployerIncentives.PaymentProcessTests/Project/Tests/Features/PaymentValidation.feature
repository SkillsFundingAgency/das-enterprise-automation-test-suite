Feature: PaymentValidation
	Test payment validation days in learning check
@employerincentivesPaymentsProcess

Scenario: Validation 90 Day check

Given an existing apprenticeship incentive
   When the Payment Run occurs
   Then the HasDaysInLearning Step in PendingPaymentValidationResult table is set to true
   Then the payment record for the first earnings is created

Given an existing apprenticeship incentive
   When the Payment Run occurs
   Then the IsInLearning Step in PendingPaymentValidationResult table is set to true
   Then the payment record for the first earnings is created

Given an existing apprenticeship incentive
   When the Payment Run occurs
   Then the HasBankDetails Step in PendingPaymentValidationResult table is set to true
   Then the payment record for the first earnings is created