Feature: CreateAccount

A short summary of the feature


Scenario: Create user Account without PAYE details
Given I create an Account 
Then I do not add paye details



@addpayedetails
@eoiaccount
Scenario: Create EOI Account with PAYE Details 
Given I create an Account 
When I add paye details
And eoi organisation details
Then I can land in the User Home page


@addpayedetails
Scenario: Create user Account with PAYE Details
Given I create an Account 
When I add paye details
And organisation details
Then I can land in the User Home page

