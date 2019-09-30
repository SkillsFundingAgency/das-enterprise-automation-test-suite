Feature: NewUserAccountE2EJourneyThree

A short summary of the feature


@addpayedetails
@addlevyfunds
@e2escenarios
Scenario: Create Employer Provider adds apprentices and approves then employer approves cohort
Given the User creates Employer account and sign an agreement
When the Employer create a cohort and send to provider to add apprentices
And the provider adds 2 apprentices approves them and sends to employer to approve
Then the Employer approves the cohorts
