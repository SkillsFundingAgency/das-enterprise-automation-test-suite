Feature: AP_E2E_NUA_AUTH_01

@addlevyfunds
@authtests
Scenario: AP_E2E_NUA_AUTH_01 Create Employer send an approved cohort then provider approves the cohort
	Given The User creates LevyEmployer account and sign an agreement
	When the Employer approves 2 cohort and sends to provider
	Then the provider adds Ulns and approves the cohorts
	Then an unauthorised user can not access the service
	And a valid user can not access different account