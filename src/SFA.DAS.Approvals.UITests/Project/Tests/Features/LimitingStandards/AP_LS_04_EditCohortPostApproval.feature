Feature: AP_LS_04_EditCohortPostApproval

@approvals
@regression

Scenario: AP_LS_04_Limiting Standards In Edit Cohort Post Approval
And employer edits an apprentice with Standard-X post approval
When provider opens apprentice requests
Then provider see warning messages about limiting standards
