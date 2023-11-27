Feature: AP_P_DC_02_DeleteDraftCohort
#Do not add regression or approvals tag, as these tests are meant to create or delete data

@deletecohortviaproviderportal
@donottakescreenshot
@testdatascenario
Scenario: AP_P_Delete_02A Draft Cohort using db
	Then A list of cohorts in draft can be deleted


@deletecohortviaproviderportal
@donottakescreenshot
@testdatascenario
Scenario: AP_P_Delete_02B Draft Cohort using key
	Then A list of cohorts in draft can be deleted using key 'Details'


#10000528 45 101
#10044607 
#10037344 138 26
#10005310 130 239
#10005077 39 182
#10005760 198 166
#10038368 263 44