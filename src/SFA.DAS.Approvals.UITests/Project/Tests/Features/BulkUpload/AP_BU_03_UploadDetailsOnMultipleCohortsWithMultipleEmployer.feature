Feature: AP_BU_03_UploadDetailsOnMultipleCohortsWithMultipleEmployer

@mytag
Scenario: AP_BU_03_Upload Details On Multiple Cohorts With Multiple Employers
	Given the Employer1 logins using existing Levy Account
	And the Employer creates 2 cohorts and sends them to provider to add apprentices
	And the Employer2 logins
	And the Employer2 creates 2 cohorts and sends them to provider to add apprentices
	When Provider add 2 apprentice details using bulkupload and sends to employer for approval