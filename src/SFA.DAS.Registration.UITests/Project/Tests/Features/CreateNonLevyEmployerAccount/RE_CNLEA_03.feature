Feature: RE_CNLEA_03

@regression
@registration
@addpayedetails
Scenario: RE_CNLEA_03_Create an Employer Account with levy declarations as 0
	When an Employer Account with Company Type Org is created
	And levy declarations are added for the past 15 months with levypermonth as 0
	Then ApprenticeshipEmployerType in Account table is marked as 0