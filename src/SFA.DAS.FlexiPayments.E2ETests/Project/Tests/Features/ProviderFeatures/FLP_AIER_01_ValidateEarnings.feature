Feature: FLP_AIER_01_ValidateEarnings

This test will be enabled when FLP-165 is dev'd and ready to merge. 

@ignore
@regression
@flexi-payments
Scenario: FLP_AIER_01 Validate Apps indicative earnings report

Given the provider logs into their account
When provider is on Apprenticeship indicative earnings report page 
Then validate correct earnings numbers are displayed