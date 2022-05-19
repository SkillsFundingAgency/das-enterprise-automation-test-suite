@approvals
Feature: AP_BU_03_UploadDetailsOnMultipleCohortsWithMultipleEmployer

@regression
@newBUJourney
Scenario: AP_BU_03_Upload Details On Multiple Cohorts With Multiple Employers
	Given the Employer1 logins using existing Levy Account
	And the Employer creates 2 cohorts and sends them to provider to add apprentices
	And the Employer2 logins
	And the Employer2 creates 2 cohorts and sends them to provider to add apprentices
	And the Employer3 logins
	And the Employer3 creates 2 cohorts and sends them to provider to add apprentices
	When Provider uses BulkUpload to add 2 apprentice details into existing cohort and 2 apprentice details into a non-existing cohort for all employers
	And Correct Information is displayed on review apprentices details page
	And Provider selects to save all but don't send to employer
	