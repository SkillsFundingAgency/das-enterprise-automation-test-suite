Feature: CreateAccountWithAgreement

A short summary of the feature

@addpayedetails
Scenario: Create user Account with PAYE Details And Sign Agreement
Given I create an Account 
When I add paye details
And organisation details
And I sign the agreement 
Then sucess message is displayed

