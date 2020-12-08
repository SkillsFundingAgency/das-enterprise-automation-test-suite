Feature: RE_CLEA_02

@regression
@registration
@addlevyfunds
Scenario: RE_CLEA_02_Create a Levy Employer Account and Sign the Agreement
	Given levy declarations are added for the past 15 months with levypermonth as 10000
	When an Employer Account with Company Type Org is created and agreement is Signed
	Then ApprenticeshipEmployerType in Account table is marked as 1