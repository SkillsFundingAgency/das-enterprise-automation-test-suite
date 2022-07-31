@approvals
Feature: AP_BU_08_UploadDetailsOnBehalfOfNonLevyEmployer

@regression
@newBUJourney
Scenario: AP_BU_08_Upload Details On Behalf Of NonLevy Employer
	Given the Employer logins using existing NonLevy Account
	And Provider uses BulkUpload to add 2 apprentice details for a non-levy employer into a non-existing cohort
	And Correct Information is displayed on review apprentices details page
	### Below step is commented since Approve option is removed for Bulkupload for the month of AUG 2022 by CMAD team to allow providers to update their SWs to cater to RPL data
	#When Provider approves the cohorts and send them to employer to approve 
	When Provider selects to save all but don't send to employer
	### Below new Step introduced as a workaournd for the issue mentioned above
	And approves the cohort from the saved draft section 
	And the Employer approves multiple cohorts
	Then New apprentice records become available in Manage Apprentice section