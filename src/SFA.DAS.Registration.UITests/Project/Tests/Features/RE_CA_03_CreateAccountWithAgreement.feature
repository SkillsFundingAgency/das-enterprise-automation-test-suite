@registration
Feature: RE_CA_03_CreateAccountWithAgreement

@addpayedetails
@regression
Scenario: RE_CA_03_Create Non Levy Account with PAYE Details And Sign Agreement
	Given I create an Account
	When I add paye details
	And add organisation details
	And I sign the agreement