@approvals
Feature: AP_E2E_NUA_05_NewUserAccount

@regression
@addlevyfunds
@e2escenarios
@whitelistedprovider
Scenario: AP_E2E_NUA_05 Create Employer Whitelisted Provider sends cohort to employer for review then employer approves then provider approves
	And The User creates LevyEmployer account and sign an agreement
	When the Employer create a cohort and send to provider to add apprentices
	And the provider adds 2 apprentices and sends to employer to review
	When the Employer approves the cohort and sends to provider
	Then the provider approves the cohorts