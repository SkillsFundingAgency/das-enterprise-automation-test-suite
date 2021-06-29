Feature: PaymentValidation
	Test payment validation checks
@employerincentivesPaymentsProcess

Scenario: Validation 90 Day check

Given an existing apprenticeship incentive
   When the Payment Run occurs
   Then the HasDaysInLearning Step in PendingPaymentValidationResult table is set to true
   And the IsInLearning Step in PendingPaymentValidationResult table is set to true
   And the HasBankDetails Step in PendingPaymentValidationResult table is set to true
   And the payment record for the first earnings is created