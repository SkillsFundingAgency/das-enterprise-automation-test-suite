Feature: FLP_E2E_EUA_01_ExisitingUserAccount

@regression
@e2escenarios
@flexi-payments
Scenario: FLP_E2E_EUA_01 Employer sends an approved cohort then provider approves the cohort
	Given the Employer logins using existing Levy Account
	When the Employer approves 2 cohort and sends to provider
	And the provider adds Ulns and Opt the learners into the pilot
	Then Provider is able to successfully approve the cohort
