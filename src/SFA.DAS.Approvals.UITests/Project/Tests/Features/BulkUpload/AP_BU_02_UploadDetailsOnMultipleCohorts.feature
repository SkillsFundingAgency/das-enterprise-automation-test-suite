Feature: AP_BU_02_UploadDetailsOnMultipleCohorts

@mytag
Scenario: AP_BU_02_Upload Details On Multiple Cohorts
	Given the provider has multiple editable cohorts
	When provider uses bulk upload to add apprentices into these cohorts
	Then the apprentice details are uploaded correctly in each cohort