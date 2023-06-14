Feature: AP_LS_03_BulkUpload

@approvals
@regression
@limitingstandards
Scenario: AP_LS_03_Limiting Standards In Bulk Upload
Given provider does not offer Standard-X
Then provider can not upload file using Standard-X
