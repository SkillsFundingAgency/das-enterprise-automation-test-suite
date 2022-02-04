@approvals
Feature: AP_BU_02_UploadDetailsOnMultipleCohorts

@regression
@newBUJourney
Scenario: AP_BU_02_Upload Details On Multiple Cohorts
	Given the Employer logins using existing Levy Account
	And the Employer creates 2 cohorts and sends them to provider to add apprentices
	When Provider add 2 apprentice details using bulkupload 
	And Correct Information is displayed on review apprentices details page