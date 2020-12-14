@approvals
Feature: AP_E2E_NUA_03_NewUserAccount

@addlevyfunds
@e2escenarios
Scenario: AP_E2E_NUA_03 Create Employer Provider adds apprentices and approves then employer approves cohort
	Given The User creates LevyEmployer account and sign an agreement
	When the Employer create a cohort and send to provider to add apprentices
	And the provider adds 2 apprentices approves them and sends to employer to approve
	Then the Employer approves the cohorts