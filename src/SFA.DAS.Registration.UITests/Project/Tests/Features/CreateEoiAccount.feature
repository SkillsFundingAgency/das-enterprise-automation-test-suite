Feature: CreateEoiAccount

@addpayedetails
@eoiaccount
@registration
Scenario: Create EOI Account with PAYE Details
	Given I create an Account
	When I add paye details
	And add eoi organisation details
	And I do not sign the eoi agreement