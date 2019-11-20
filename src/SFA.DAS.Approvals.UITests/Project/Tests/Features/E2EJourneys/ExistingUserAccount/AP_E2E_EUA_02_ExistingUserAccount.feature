@approvals
Feature: AP_E2E_EUA_02_ExistingUserAccount

@regression
@e2escenarios
Scenario: AP_E2E_EUA_02 Employer sends cohort to provider for review then provider approves then employer approves
	Given the Employer login using existing levy account
	When the Employer adds 2 cohort and sends to provider
	And the provider adds Ulns and approves the cohorts and sends to employer
	Then the Employer approves the cohorts