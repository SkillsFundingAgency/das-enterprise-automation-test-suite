@employerincentivesPaymentsProcess
@PaymentValidation
@eiRegression
Feature: PaymentValidation
	Test payment validation checks
@employerincentivesPaymentsProcess
@PaymentValidation

Scenario: Validation 90 Day check

Given an existing apprenticeship incentive
   When the Payment Run occurs
   Then the HasDaysInLearning Step in PendingPaymentValidationResult table for the FirstPayment is set to true
   And the IsInLearning Step in PendingPaymentValidationResult table for the FirstPayment is set to true
   And the HasBankDetails Step in PendingPaymentValidationResult table for the FirstPayment is set to true
   And the HasIlrSubmission Step in PendingPaymentValidationResult table for the FirstPayment is set to true
   And the PaymentsNotPaused Step in PendingPaymentValidationResult table for the FirstPayment is set to true
   And the HasSignedMinVersion Step in PendingPaymentValidationResult table for the FirstPayment is set to true   
   And the HasLearningRecord Step in PendingPaymentValidationResult table for the FirstPayment is set to true   
   And the payment record for the first earnings is created

Scenario: Phase 3 Validation success - Perform HasSignedMinVersion Validation Check for Phase 3  ( Start Date 01-10-2021 Run the Payment Process for Period 05 Academicyear 2122)

	Given an existing Phase3 apprenticeship incentive submitted in Academic Year 2122 and signed version 7
	When the Payment Run occurs
	Then the HasSignedMinVersion Step in PendingPaymentValidationResult table for the FirstPayment is set to true
	And the payment record for the first earnings is created

Scenario: Phase 3 Validation failure - Perform HasSignedMinVersion Validation Check for Phase 3  ( Start Date 01-10-2021 Run the Payment Process for Period 05 Academicyear 2122)

	Given an existing Phase3 apprenticeship incentive submitted in Academic Year 2122 and signed version 6
	When the Payment Run occurs
	Then the HasSignedMinVersion Step in PendingPaymentValidationResult table for the FirstPayment is set to false
	And the payment record for the first earnings is not created

