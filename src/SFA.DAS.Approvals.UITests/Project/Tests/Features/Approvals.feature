Feature: Approvals

A short summary of the feature


@addpayedetails
Scenario: Create Employer send an approved cohort then provider approves the cohort
Given I have levy declarations
Given the User creates Employer account and sign an agreement
When the Employer approves 2 cohort and sends to provider
Then the provider adds Ulns and approves the cohorts


@addpayedetails
Scenario: Create Employer send cohort to provider for review then provider approves then employer approves
Given I have levy declarations
Given the User creates Employer account and sign an agreement
When the Employer approves 2 cohort and sends to provider
And the provider adds Ulns and approves the cohorts and sends to employer
Then the Employer approves the cohorts


@addpayedetails
Scenario: Create Employer Provider adds apprentices and approves then employer approves cohort
Given I have levy declarations
Given the User creates Employer account and sign an agreement
When the Employer create a cohort and send to provider to add apprentices
And the provider adds 2 apprentices approves them and sends to employer to approve
Then the Employer approves the cohorts
