Feature: CreateAccountThree

A short summary of the feature

@addpayedetails
Scenario: Create user Account with PAYE Details Three
Given I create an Account 
When I add paye details
Then I can land in the User Home page
