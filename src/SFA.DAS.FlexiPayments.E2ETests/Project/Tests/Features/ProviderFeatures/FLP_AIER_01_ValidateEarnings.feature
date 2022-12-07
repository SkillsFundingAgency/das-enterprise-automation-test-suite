Feature: FLP_AIER_01_ValidateEarnings

@ignoreinpp
@regression
@flexi-payments
Scenario: FLP_AIER_01 Validate Apps indicative earnings report

Given the provider logs into their account
When provider is on Apprenticeship indicative earnings report page 
Then validate correct earnings numbers are displayed