Feature: Approvals

A short summary of the feature


Scenario: Employer sends an approved cohort then provider approves the cohort
Given the Employer login using existing levy account
When the Employer approves 2 cohort and sends to provider
Then the provider adds Ulns and approves the cohorts


@addpayedetails
Scenario: Create Employer send an approved cohort then provider approves the cohort
Given I have levy declarations
Given the User creates Employer account and sign an agreement
When the Employer approves 2 cohort and sends to provider
Then the provider adds Ulns and approves the cohorts
