Feature: AP_E2E_PF_LY_01


@addpayedetails
@addlevyfunds
@perfteste2e
@donottakescreenshot
Scenario Outline: AP_E2E_PF_LY_01 Create Employer send an approved cohort then provider approves the cohort
	Given The User creates NonLevyEmployer account and sign an agreement
	When the Employer approves 2 cohort and sends to provider
	Then the provider adds Ulns and approves the cohorts

	Examples: 
	| testdata |
	| 1        |
	| 2        |
	| 3        |
	| 4        |
	| 5        |
	| 6        |
	| 7        |
	| 8        |
	| 9        |
	| 10       |
	| 11       |
	| 12       |
	| 13       |
	| 14       |
	| 15       |
	| 16       |
	| 17       |
	| 18       |
	| 19       |
	| 20       |
	| 21       |
	| 22       |
	| 23       |
	| 24       |
	| 25       |