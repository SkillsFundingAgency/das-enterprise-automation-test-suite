Feature: AP_P_DC_02_DeleteDraftCohort
#Do not add regression or approvals tag, as these tests are meant to create or delete data

@deletecohortviaproviderportal
@donottakescreenshot
@testdatascenario
Scenario: AP_P_Delete_02 Draft Cohort using db
	Then A list of cohorts in draft can be deleted
