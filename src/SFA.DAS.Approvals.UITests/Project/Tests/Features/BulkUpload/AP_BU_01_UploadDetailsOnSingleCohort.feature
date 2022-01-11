Feature: AP_BU_01_UploadDetailsOnSingleCohort

@mytag
Scenario: AP_BU_01_Upload Details On Single Cohort
	Given the provider has an editable cohort
	When provider uses bulk upload to add multiple apprentices into that cohort
	Then the apprentice details are uploaded correctly