@approvals
Feature: AP_BU_08_UploadDetailsOnBehalfOfNonLevyPayingEmployer

@regression
@newBUJourney
Scenario: AP_BU_08_Upload Details On Behalf Of NonLevy Paying Employer
	Given the Employer logins using existing NonLevy Account
	And Provider uses BulkUpload to add 2 apprentice details for a non-levy employer into a non-existing cohort
	And Correct Information is displayed on review apprentices details page
	When Provider approves the cohorts and send them to employer to approve
	And the Employer approves multiple cohorts
	Then New apprentice records become available in Manage Apprentice section