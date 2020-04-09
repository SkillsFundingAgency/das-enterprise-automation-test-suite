Feature: RE_PR_01

@regression
@registration
@addpayedetails
Scenario: RE_PR_01 Provider Registration
Given the provider invite an employer
Then the invited employer status in "Invitation sent"
When the employer sets up the user
Then the invited employer status in "Account started"
When the employer adds PAYE from Account Home Page
Then the invited employer status in "PAYE scheme added"
Then the invited employer status in "Legal agreement signed"