Feature: AP_P_DC_02AA_DeleteDraftCohort
#Do not add regression or approvals tag, as these tests are meant to create or delete data

@deletecohortviaproviderportal
@donottakescreenshot
@testdatascenario
@testtoexecuteon27Nov
Scenario: AP_P_Delete_02AA Draft Cohort using key
	Then A 1 list of cohorts in draft can be deleted using key 'Details'
