Feature: EmployerDeleteCohort

A short summary of the feature

@regression
Scenario: Employer view edit and delete apprentices and cohort
Given the Employer login using existing levy account
And Employer adds 2 apprentices to current cohort
And Employer saves the cohort without sending to provider
Then Employer is able to view saved cohort from Draft
And Employer is able to edit all apprentices before approval
And Employer is able to delete all apprentices before approval
And Employer is able to delete the cohort before approval