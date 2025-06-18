@approvals
Feature: AP_E2E_NUA_02_NewUserAccount

@addlevyfunds
@e2escenarios
Scenario: AP_E2E_NUA_02 Create Employer send cohort to provider for review then provider approves then employer approves
	Given The User creates LevyEmployer account and sign an agreement
	When the Employer adds 2 apprentices and sends to provider
	And the provider adds Ulns and approves the cohorts and sends to employer
	Then the Employer approves the cohorts

