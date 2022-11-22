Feature: FLP_E2E_EUA_02_ExisitingUserAccount

@regression
@e2escenarios
@flexi-payments
Scenario: FLP_E2E_EUA_02 Employer sends cohort to provider for review then provider approves then employer approves
	Given the Employer logins using existing Levy Account
	When the Employer adds 2 apprentices and sends to provider
	And the provider adds Ulns and opts the learners out of the pilot 
	Then Provider is able to successfully approve the cohort
	And the Employer approves the cohorts