@registration
Feature: RE_CA_01_CreateAccount

@regression
Scenario: RE_CA_01_01_Create Account without PAYE details
	Given I create an Account
	Then I do not add paye details

@regression
@addpayedetails
Scenario: RE_CA_01_02_Create Non Levy Account with PAYE Details
	Given I create an Account
	When I add paye details
	And add organisation details
	When I do not sign the agreement
	Then I will land in the User Home page