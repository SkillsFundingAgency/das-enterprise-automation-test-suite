Feature: NewUserAccountE2EJourneyFour

A short summary of the feature



@addpayedetails
Scenario: Create Employer Provider sends cohort to employer for review then employer approves then provider approves
Given I have levy declarations
And the User creates Employer account and sign an agreement
When the Employer create a cohort and send to provider to add apprentices
And the provider adds 2 apprentices and sends to employer to review
When the Employer approves the cohort and sends to provider
Then the provider approves the cohorts

