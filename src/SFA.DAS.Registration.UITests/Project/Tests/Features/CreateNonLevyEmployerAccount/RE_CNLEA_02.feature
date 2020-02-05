Feature: RE_CNLEA_02

@regression
@registration
@addpayedetails
Scenario: RE_CNLEA_02_Create a NonLevy Account and land on the Agreement Page
	Given I create an Account
	When I add paye details
	And add organisation details
	Then I will land in the Organisation Agreement page