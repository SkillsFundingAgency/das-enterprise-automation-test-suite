Feature: Approvals

A short summary of the feature



@addpayedetails
Scenario: Journey 1
Given I login as an existing Employer user with an organisation and signed employer agreement
And I navigate to Apprentices home page
When I create a cohort and select employer adds apprentices
And Employer adds 2 apprentices to current cohort
And Employer approves the cohort and sends to provider
Then I should be on instructions-sent-end page
When I login as a provider
And Provider navigates to review current cohort
And Provider edits all apprentices and enters Ulns
And Provider approves the cohort
Then I should be on request-approved page

@addpayedetails
Scenario: Employer sends an approved cohort then provider approves the cohort
Given I have levy declarations
Given the User creates Employer account and sign an agreement
When the Employer approves 2 cohort and sends to provider
#And the provider adds Ulns and approves the cohorts
#Then the Employer should see request approved


