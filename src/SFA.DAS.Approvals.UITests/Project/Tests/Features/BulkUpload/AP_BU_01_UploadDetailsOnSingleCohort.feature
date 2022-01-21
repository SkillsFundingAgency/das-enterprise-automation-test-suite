Feature: AP_BU_01_UploadDetailsOnSingleCohort

@mytag
Scenario: AP_BU_01_Upload Details On Single Cohort
	Given the Employer logins using existing Levy Account
	And the Employer create a cohort and send to provider to add apprentices
	When Provider add 2 apprentice details using bulkupload and sends to employer for approval