Feature: RE_CNLEA_02

@regression
@registration
@addnonlevyfunds
Scenario: RE_CNLEA_02_Create an Employer Account with levy declarations as 0
	Given levy declarations are added for the past 15 months with levypermonth as 0
	When an Employer Account with Company Type Org is created and agreement is Signed
	Then ApprenticeshipEmployerType in Account table is marked as 0