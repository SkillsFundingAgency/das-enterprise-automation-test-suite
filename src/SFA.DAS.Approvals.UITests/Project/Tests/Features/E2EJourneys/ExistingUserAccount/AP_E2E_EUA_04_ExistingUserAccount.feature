@approvals
Feature: AP_E2E_EUA_04_ExistingUserAccount

@regression
@e2escenarios
Scenario: AP_E2E_EUA_04 Provider sends cohort to employer for review then employer approves then provider approves
	Given the Employer logins using existing Levy Account
	When the Employer create a cohort and send to provider to add apprentices
	And the provider adds 2 apprentices and sends to employer to review
	When the Employer approves the cohort and sends to provider
	Then the provider approves the cohorts