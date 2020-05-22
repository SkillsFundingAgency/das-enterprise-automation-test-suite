Feature: AP_PSR_01_CreateAndAmendReport

@approvals
@regression
@addpayedetails
Scenario: AP_PSR_01_CreateAndAmendReport
Given The User creates NonLevyEmployer account and sign an agreement
Then the employer can create a new report
And then employer can edit a submitted report