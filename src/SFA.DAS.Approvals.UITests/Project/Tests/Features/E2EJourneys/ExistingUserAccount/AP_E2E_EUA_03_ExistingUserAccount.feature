@approvals
Feature: AP_E2E_EUA_03_ExistingUserAccount

@regression
@e2escenarios
Scenario: AP_E2E_EUA_03 Provider adds apprentices and approves then employer approves cohort
	Given the Employer logins using existing Levy Account
	When the Employer create a cohort and send to provider to add apprentices
	And the provider adds 2 apprentices approves them and sends to employer to approve
	Then the Employer approves the cohorts