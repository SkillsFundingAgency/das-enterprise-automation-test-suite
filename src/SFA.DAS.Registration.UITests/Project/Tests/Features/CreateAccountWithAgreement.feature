Feature: CreateAccountWithAgreement

@addpayedetails
Scenario: Create Non Levy Account with PAYE Details And Sign Agreement
	Given I create an Account
	When I add paye details
	And add organisation details
	And I sign the agreement
	Then sucess message is displayed