Feature: ApprovalsExistingUsers

A short summary of the feature


Scenario: Employer sends an approved cohort then provider approves the cohort
Given the Employer login using existing levy account
When the Employer approves 2 cohort and sends to provider
Then the provider adds Ulns and approves the cohorts

Scenario: Employer sends cohort to provider for review then provider approves then employer approves		
Given the Employer login using existing levy account
When the Employer adds 2 cohort and sends to provider
And the provider adds Ulns and approves the cohorts and sends to employer
Then the Employer approves the cohorts

Scenario: Provider adds apprentices and approves then employer approves cohort
Given the Employer login using existing levy account
When the Employer create a cohort and send to provider to add apprentices
And the provider adds 2 apprentices approves them and sends to employer to approve
Then the Employer approves the cohorts