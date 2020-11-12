Feature: RE_CA_PF_LY_01

@perftestlevy
@addpayedetails
@donottakescreenshot
@addlevyprefix
Scenario Outline: RE_CA_PF_LY_01_Create a Levy Account and Sign the Agreement
	Given levy declarations are added for the past 15 months with levypermonth as 10000
	When an Employer Account with Company Type Org is created and agreement is Signed
	Then add accountid to the test data
	And ApprenticeshipEmployerType in Account table is marked as 1
	

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