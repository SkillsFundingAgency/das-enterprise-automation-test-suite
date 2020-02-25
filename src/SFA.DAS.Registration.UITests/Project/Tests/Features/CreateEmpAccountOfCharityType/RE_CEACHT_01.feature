Feature: RE_CEACHT_01

@regression
@registration
@addpayedetails
Scenario: RE_CEACHT_01_Create an Employer Account with Charity Type Org
	When an Employer Account with Charity Type Org is created and agreement is Signed
	Then ApprenticeshipEmployerType in Account table is marked as 0