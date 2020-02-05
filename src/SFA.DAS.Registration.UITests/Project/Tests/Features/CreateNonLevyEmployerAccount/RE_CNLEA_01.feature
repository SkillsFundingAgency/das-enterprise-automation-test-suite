Feature: RE_CNLEA_01

@regression
@registration
@addpayedetails
Scenario: RE_CNLEA_01_Create a NonLevy Employer Account and Not Sign the Agreement
	Given I create an Account
	When I add paye details
	And add organisation details
	When I do not sign the agreement
	Then I will land in the User Home page