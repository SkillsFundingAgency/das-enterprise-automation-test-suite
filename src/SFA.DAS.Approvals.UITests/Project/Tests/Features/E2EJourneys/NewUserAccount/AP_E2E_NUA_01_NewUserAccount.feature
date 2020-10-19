Feature: AP_E2E_NUA_01_NewUserAccount

@addpayedetails
@addlevyfunds
@e2escenarios
Scenario: AP_E2E_NUA_01 Create Employer send an approved cohort then provider approves the cohort
	Given The User creates LevyEmployer account and sign an agreement
	When the Employer approves 2 cohort and sends to provider
	Then the provider adds Ulns and approves the cohorts