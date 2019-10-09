Feature: CreateAccountWithOutAgreement

@addpayedetails
Scenario: Create Non Levy Account with PAYE Details And Do Not Sign Agreement
	Given I create an Account
	When I add paye details
	And add organisation details
	And I do not sign the agreement
	Then I will land in the User Home page