Feature: RE_CNLEA_02

@regression
@registration
@addpayedetails
Scenario: RE_CNLEA_02_Create a NonLevy Account and land on the Agreement Page
	When an User Account is created
	And the User adds PAYE details
	And adds Organisation details
	Then the Employer lands on the Organisation Agreement page