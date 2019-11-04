@registration
Feature: CreateAccount

Scenario: Create Account without PAYE details
	Given I create an Account
	Then I do not add paye details

@addpayedetails
Scenario: Create Non Levy Account with PAYE Details
	Given I create an Account
	When I add paye details
	And add organisation details
	When I do not sign the agreement
	Then I will land in the User Home page