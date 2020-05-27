Feature: AP_PSR_01_CreateAndAmendReport

@approvals
@regression
Scenario: AP_PSR_01_CreateAndAmendReport
Given the Employer logins using existing NonLevy Account
Then the employer can create a new report
And then employer can edit a submitted report