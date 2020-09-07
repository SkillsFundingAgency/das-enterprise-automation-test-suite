@approvals
Feature: AP_E2E_EUA_05_ExistingUserAccount

@regression
@e2escenarios
@onemonthbeforecurrentacademicyearstartdate
Scenario: AP_E2E_EUA_05 Payment Completion event marks the apprenticeship as Complete
	Given the Employer logins using existing Levy Account
	When the Employer approves 1 cohort and sends to provider
	Then the provider adds Ulns and approves the cohorts
    And a new live apprentice record is created 
	When PaymentsCompletion event is received
	Then the apprenticeship status changes to completed
	And Apprentice details or status can no longer be changed