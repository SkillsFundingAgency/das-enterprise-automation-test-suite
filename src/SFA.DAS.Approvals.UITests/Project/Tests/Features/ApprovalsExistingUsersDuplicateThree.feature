Feature: ApprovalsExistingUsersDuplicateThree

A short summary of the feature


Scenario: Employer sends an approved cohort then provider approves the cohort
Given the Employer login using existing levy account
When the Employer approves 2 cohort and sends to provider
Then the provider adds Ulns and approves the cohorts

