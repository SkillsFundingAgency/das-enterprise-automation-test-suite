Feature: CreateLevyAccountOne

@addpayedetails
Scenario: Create Levy Account For Approvals
Given I have levy declarations
Given I create an Account 
When I add paye details
And organisation details
When I do not sign the agreement
Then I will land in the User Home page
