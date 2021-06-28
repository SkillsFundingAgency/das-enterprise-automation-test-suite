Feature: AP_E2E_PF_NL_01

@addnonlevyfunds
@selectstandardcourse
@perftest
@donottakescreenshot
@liveapprentice
Scenario Outline: AP_E2E_PF_NL_01 Non Levy Employer sends an approved cohort then provider approves the cohort
	Given The User creates LevyEmployer account and sign an agreement
	When the Employer uses the reservation to create and approve 1 cohort and sends to provider
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