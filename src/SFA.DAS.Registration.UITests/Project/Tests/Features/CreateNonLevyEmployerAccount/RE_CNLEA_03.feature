Feature: RE_CNLEA_03

@regression
@registration
@addpayedetails
Scenario: RE_CNLEA_03_Create a NonLevy Account and Sign Agreement
	Given I create an Account
	When I add paye details
	And add organisation details
	And I sign the agreement