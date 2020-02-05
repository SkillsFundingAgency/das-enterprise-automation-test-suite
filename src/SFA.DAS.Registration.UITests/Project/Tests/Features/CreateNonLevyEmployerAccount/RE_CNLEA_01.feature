Feature: RE_CNLEA_01

@regression
@registration
@addpayedetails
Scenario: RE_CNLEA_01_Create a NonLevy Employer Account and Not Sign the Agreement
	When an User Account is created
	And the User adds PAYE details
	And adds Organisation details
	And the Employer does not sign the Agreement
	Then the Employer Home page is displayed