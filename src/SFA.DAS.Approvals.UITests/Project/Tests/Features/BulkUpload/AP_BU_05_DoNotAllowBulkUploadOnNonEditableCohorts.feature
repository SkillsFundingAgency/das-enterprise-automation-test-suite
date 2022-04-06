@approvals
Feature: AP_BU_05_DoNotAllowBulkUploadOnNonEditableCohorts

@regression
@newBUJourney
Scenario: AP_BU_05_Do Not Allow Bulk Upload On Non Editable Cohorts	
	Given the provider has a cohort which is with employer
	When the provider tries a bulk upload file to add apprentices in that cohort
	Then Non Editable Cohorts error message is displayed
	Given the provider has a cohort which is with transfer-sender
	When the provider tries a bulk upload file to add apprentices in that cohort
	Then Transfer Sender Cohorts error message is displayed	
	Given the provider has a cohort as a result of change of party
	When the provider tries a bulk upload file to add apprentices in that cohort
	Then an error message is displayed