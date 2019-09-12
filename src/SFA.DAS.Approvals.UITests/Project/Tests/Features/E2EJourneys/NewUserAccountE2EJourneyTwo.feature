Feature: NewUserAccountE2EJourneyTwo

A short summary of the feature

@addpayedetails
Scenario: Create Employer send cohort to provider for review then provider approves then employer approves
Given I have levy declarations
Given the User creates Employer account and sign an agreement
When the Employer approves 2 cohort and sends to provider
And the provider adds Ulns and approves the cohorts and sends to employer
Then the Employer approves the cohorts


