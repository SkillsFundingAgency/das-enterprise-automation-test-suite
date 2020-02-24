Feature: RE_CNLEA_01

@regression
@registration
@addpayedetails
Scenario: RE_CNLEA_01_Create a NonLevy Account and Sign Agreement
	When an User Account is created
	And the User adds PAYE details
	And adds Organisation details
	Then the Employer is able to Sign the Agreement