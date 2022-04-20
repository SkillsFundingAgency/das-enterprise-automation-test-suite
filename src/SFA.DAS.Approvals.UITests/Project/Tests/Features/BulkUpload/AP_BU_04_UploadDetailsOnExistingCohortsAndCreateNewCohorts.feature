@approvals
Feature: AP_BU_04_UploadDetailsOnExistingCohortsAndCreateNewCohorts

@regression
@newBUJourney
Scenario: AP_BU_04_Upload Details On Existing Cohorts And Create New Cohorts
	Given the Employer logins using existing Levy Account
	When the Employer adds 2 apprentices and sends to provider
	And the provider adds Ulns	
	When Provider uses BulkUpload to add 2 apprentice details into existing cohort and 2 apprentice details into a non-existing cohort
	Then Correct Information is displayed on review apprentices details page
	And Provider approves the cohorts and send them to employer to approve
	When the Employer approves multiple cohorts
	Then New apprentice records become available in Manage Apprentice section	