Feature: RE_CLEA_01

@regression
@registration
@addpayedetails
Scenario: RE_CLEA_01_Create a Levy Account
	Given levy declarations is added for past 15 months with levypermonth as 10000
	Given I create an Account
	When I add paye details
	And add organisation details
	When I do not sign the agreement
	Then I will land in the User Home page