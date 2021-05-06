Feature: AP_CA_PF_NL_01

@perftest
@addnonlevyfunds
@donottakescreenshot
Scenario Outline: AP_CA_PF_NL_01_Create a NonLevy Employer Account and grant Create Cohort permission to a provider
	When an Employer Account with Company Type Org is created and agreement is Signed
	Then create cohort permission is granted to a provider

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