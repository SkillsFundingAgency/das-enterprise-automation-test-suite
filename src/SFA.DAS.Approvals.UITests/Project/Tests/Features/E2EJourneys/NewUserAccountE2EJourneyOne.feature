Feature: NewUserAccountE2EJourneyOne

A short summary of the feature


@addpayedetails
@addlevyfunds
@e2escenarios
Scenario: Create Employer send an approved cohort then provider approves the cohort
Given the User creates Employer account and sign an agreement
When the Employer approves 2 cohort and sends to provider
Then the provider adds Ulns and approves the cohorts

