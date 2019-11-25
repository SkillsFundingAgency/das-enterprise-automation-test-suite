@registration
Feature: RE_CA_05_CreateEoiAccount

@addpayedetails
@eoiaccount
@regression
Scenario: RE_CA_05_Create EOI Account with PAYE Details
	Given I create an Account
	When I add paye details
	And add eoi organisation details
	And I do not sign the eoi agreement