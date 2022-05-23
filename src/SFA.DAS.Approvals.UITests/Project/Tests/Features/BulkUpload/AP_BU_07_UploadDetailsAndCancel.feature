@approvals
Feature: AP_BU_07_UploadDetailsAndCancel
	

@regression
@newBUJourney
Scenario:  AP_BU_07_Upload Details then Cancel
	Given the Employer logins using existing Levy Account
	And the Employer create a cohort and send to provider to add apprentices
	When Provider add 2 apprentice details using bulkupload 
	And Correct Information is displayed on review apprentices details page
	And Provider selects to Cancel bulk upload
	And Provider says No on Confirm cancel confirmation page
	And Correct Information is displayed on review apprentices details page
	And Provider selects to Cancel bulk upload
	And Provider says Yes on Confirm cancel confirmation page
	And Upload cancelled confirmation page is displayed
