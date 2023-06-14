Feature: AP_LS_01_LimitingStandardsInEditCohortJourney

@approvals
@regression
@limitingstandards
Scenario: AP_LS_01_Limiting Standards In Edit Cohort Journey
Given Provider does not offer Standard-X
And Provider receives a cohort that contains Standard-X
When provider opens the cohort
#Then Provider see warning messages about limiting standards
#And Provider is unable to approve the cohort
#When provider tries to edit the Standard
#Then Standard-X is not listed in the available Standards
