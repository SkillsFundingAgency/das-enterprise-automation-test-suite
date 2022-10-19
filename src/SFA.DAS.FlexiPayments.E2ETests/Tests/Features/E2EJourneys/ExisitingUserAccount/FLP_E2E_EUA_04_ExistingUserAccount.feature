Feature: FLP_E2E_EUA_04_ExistingUserAccount

@regression
@e2escenarios
@flexi-payments
Scenario: FLP_E2E_EUA_04 Provider sends cohort to employer for review then employer approves then provider approves
	Given the Employer logins using existing Levy Account
	When the Employer create a cohort and send to provider to add apprentices
	And the provider opts 2 learner into the pilot
	And the provider sends the cohort to employer to approve
	When the Employer approves the cohort and sends to provider
	Then the provider approves the cohorts