Feature: Approvals

A short summary of the feature


@addpayedetails
Scenario: Create Employer send an approved cohort then provider approves the cohort
Given I have levy declarations
Given the User creates Employer account and sign an agreement
When the Employer approves 2 cohort and sends to provider
Then the provider adds Ulns and approves the cohorts
