Feature: CreateAccountOne

A short summary of the feature

@addpayedetails
Scenario: Create Non Levy Account with PAYE Details will land in the Agreement Page
Given I create an Account 
When I add paye details
And organisation details
Then I will land in the Organisation Agreement page