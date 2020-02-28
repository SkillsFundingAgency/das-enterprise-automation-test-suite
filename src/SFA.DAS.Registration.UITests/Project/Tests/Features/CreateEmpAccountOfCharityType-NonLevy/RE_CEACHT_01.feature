Feature: RE_CEACHT_01

@regression
@registration
@addpayedetails
Scenario: RE_CEACHT_01_Create an Employer Account with Charity Type Org
	When an User Account is created
	And the User adds PAYE details
	And adds Charity Type Organisation details
	And the Employer Signs the Agreement
	Then the Employer Home page is displayed
	Then ApprenticeshipEmployerType in Account table is marked as 0