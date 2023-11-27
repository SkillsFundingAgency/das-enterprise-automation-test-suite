Feature: AP_P_DC_01AA_DeleteReadyForReviewCohort
#Do not add regression or approvals tag, as these tests are meant to create or delete data

@deletecohortviaproviderportal
@donottakescreenshot
@testdatascenario
@testtoexecuteon27Nov
Scenario: AP_P_Delete_01AA Ready to review Cohort using Key
	Then A 1 list of cohorts ready for review can be deleted using key 'Details'