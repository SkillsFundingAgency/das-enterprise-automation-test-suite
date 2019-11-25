@registration
Feature: RE_CA_02_CreateAccountOne

@addpayedetails
@regression
Scenario: RE_CA_02_Create Non Levy Account with PAYE Details will land in the Agreement Page
	Given I create an Account
	When I add paye details
	And add organisation details
	Then I will land in the Organisation Agreement page