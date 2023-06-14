Feature: AP_LS_01_LimitingStandardsInEditCohort

@approvals
@regression
@limitingstandards
Scenario: AP_LS_01_Limiting Standards In Edit Cohort
Given provider does not offer Standard-X
And provider receives a apprentice request that contains Standard-X
When provider opens apprentice requests
Then provider see warning messages about limiting standards
