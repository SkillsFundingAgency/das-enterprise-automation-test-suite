@approvals
Feature: AP_BU_04_UploadDetailsOnExistingCohortsAndCreateNewCohorts

@regression
@newBUJourney
Scenario: AP_BU_04_Upload Details On Existing Cohorts And Create New Cohorts
	Given the Employer logins using existing Levy Account
	And the Employer create a cohort and send to provider to add apprentices
	When Provider uses BulkUpload to add 2 apprentice details into existing cohort and 2 apprentice details into a non-existing cohort
	Then Correct Information is displayed on review apprentices details page
	And Provider approves the cohorts and send them to employer to approve
	When the Employer approves the cohorts
	Then New apprentice records become available in Manage Apprentice section
	#Then a new live apprenticeship record is created with new Provider