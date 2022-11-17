Feature: FLP_E2E_EUA_03_ExistingUserAccount

@regression
@e2escenarios
@flexi-payments
Scenario: FLP_E2E_EUA_03 Provider adds apprentices and approves then employer approves cohort
	Given the Employer logins using existing Levy Account
	When the Employer create a cohort and send to provider to add apprentices
	And the provider opts 1 learner into the pilot
	And the provider opts 1 learner out of the pilot
	And the provider sends the cohort to employer to approve
	Then the Employer approves the cohorts