Feature: AP_Pro_05_BulkUpload
	
@approvals
@regression
Scenario: AP_Pro_05 Provider Adds apprentices via bulk upload
	Given the Employer logins using existing Levy Account
	And the Employer create a cohort and send to provider to add apprentices
	When Provider add 2 apprentice details using bulk upload and sends to employer for approval
	Then Provider is able to view the cohort with employer