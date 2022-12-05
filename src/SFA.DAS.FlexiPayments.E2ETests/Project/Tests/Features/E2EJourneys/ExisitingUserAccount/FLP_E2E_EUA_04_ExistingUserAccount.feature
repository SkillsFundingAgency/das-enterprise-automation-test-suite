Feature: FLP_E2E_EUA_04_ExistingUserAccount

@regression
@e2escenarios
@flexi-payments
Scenario: FLP_E2E_EUA_04 Provider sends cohort to employer for review then employer approves then provider approves
	Given the Employer logins using existing Levy Account
	And Provider creates a new cohort
	And provider add leaners details and opts them into the pilot
	When the provider sends the cohort to employer to approve
	And the Employer approves the cohort and sends to provider
	Then the provider approves the cohorts