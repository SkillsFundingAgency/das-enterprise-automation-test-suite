Feature: AP_P_DC_01_DeleteReadyForReviewCohort
#Do not add regression or approvals tag, as these tests are meant to create or delete data

@deletecohortviaproviderportal
@donottakescreenshot
@testdatascenario
Scenario: AP_P_Delete_01 Ready to review Cohort using db
	Then A list of cohorts ready for review can be deleted
