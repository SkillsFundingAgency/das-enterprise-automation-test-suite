@approvals
Feature: AP_BU_08_UploadDetailsOnBehalfOfNonLevyPayingEmployer

@regression
@newBUJourney
Scenario: AP_BU_08_Upload Details On Behalf Of NonLevy Paying Employer
	Given the Employer logins using existing NonLevy Account
	Given Provider uses BulkUpload to add 2 apprentice details for a non-levy employer into a non-existing cohort
	And Correct Information is displayed on review apprentices details page
	Then Provider approves the cohorts and send them to employer to approve
	When the Employer approves multiple cohorts
	Then New apprentice records become available in Manage Apprentice section