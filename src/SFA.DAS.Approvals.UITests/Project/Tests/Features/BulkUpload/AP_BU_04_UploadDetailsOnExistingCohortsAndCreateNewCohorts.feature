Feature: AP_BU_04_UploadDetailsOnExistingCohortsAndCreateNewCohorts

@mytag
Scenario: AP_BU_04_Upload Details On Existing Cohorts And Create New Cohorts
	Given the provider has multiple editable cohorts
	And the provider has permission to create new cohort
	When the provider creates a bulk upload file to add apprentices in existing and new cohorts
	Then the apprentice details are uploaded correctly in each cohort