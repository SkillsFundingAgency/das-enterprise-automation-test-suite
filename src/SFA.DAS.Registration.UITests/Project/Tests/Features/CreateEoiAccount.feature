Feature: CreateEoiAccount

A short summary of the feature

@addpayedetails
@eoiaccount
Scenario: Create EOI Account with PAYE Details 
	Given I create an Account 
	When I add paye details
	And eoi organisation details
	And I do not sign the eoi agreement 

