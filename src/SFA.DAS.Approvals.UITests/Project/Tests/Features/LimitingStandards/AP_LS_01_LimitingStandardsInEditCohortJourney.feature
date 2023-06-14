Feature: AP_LS_01_LimitingStandardsInEditCohortJourney

@approvals
@regression
@limitingstandards
Scenario: AP_LS_01_Limiting Standards In Edit Cohort Journey
Given Provider does not offer Standard-X
And Provider receives a apprentice request that contains Standard-X
When provider opens apprentice requests
Then Provider see warning messages about limiting standards
