Feature: AP_LS_02_EditCohortPostApproval

@approvals
@regression
Scenario: AP_LS_02_Limiting Standards In Edit Cohort Post Approval
And employer edits an apprentice with Standard-X post approval
When provider opens the cohort
Then provider see warning messages in review changes page
