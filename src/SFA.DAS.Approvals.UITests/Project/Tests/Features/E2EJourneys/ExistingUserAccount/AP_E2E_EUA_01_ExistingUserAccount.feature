@approvals
Feature: AP_E2E_EUA_01_ExistingUserAccount

@regression
@e2escenarios
Scenario: AP_E2E_EUA_01 Employer sends an approved cohort then provider approves the cohort
	Given the Employer logins using existing Levy Account
	When the Employer approves 2 cohort and sends to provider
	Then the provider adds Ulns and approves the cohorts