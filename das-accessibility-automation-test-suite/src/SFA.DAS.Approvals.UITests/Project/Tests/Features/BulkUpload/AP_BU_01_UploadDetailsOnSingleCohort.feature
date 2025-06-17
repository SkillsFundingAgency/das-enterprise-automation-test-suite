@approvals
Feature: AP_BU_01_UploadDetailsOnSingleCohort

@regression
@newBUJourney
Scenario: AP_BU_01_Upload Details On Single Cohort
	Given the Employer logins using existing Levy Account
	And the Employer create a cohort and send to provider to add apprentices
	When Provider add 2 apprentice details using bulkupload 
	And Correct Information is displayed on review apprentices details page
	And User selects to upload an amended file
	And Provider selects Yes on confirmation for upload an amended file
	And Provider uploads another file
	And Correct Information is displayed on review apprentices details page
	And User selects to upload an amended file through link
	And Provider selects No on confirmation for upload an amended file
	And Correct Information is displayed on review apprentices details page
	And Provider selects to save all but don't send to employer
