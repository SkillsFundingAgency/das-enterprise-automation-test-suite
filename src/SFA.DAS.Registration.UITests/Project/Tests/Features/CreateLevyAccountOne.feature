Feature: CreateLevyAccountOne

@addpayedetails
@addlevyfunds
Scenario: Create Levy Account For Approvals
Given I create an Account 
When I add paye details
And add organisation details
When I sign the agreement
Then I will land in the User Home page
