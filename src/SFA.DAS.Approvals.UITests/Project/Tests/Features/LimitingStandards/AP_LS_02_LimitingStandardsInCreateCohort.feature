Feature: AP_LS_02_LimitingStandardsInCreateCohort

@approvals
@regression
@limitingstandards
Scenario: AP_LS_02_Limiting Standards In Create Cohort
Given provider does not offer Standard-X
Then provider should not see Standard-X in add apprentice details page
And provider can not upload file using Standard-X
