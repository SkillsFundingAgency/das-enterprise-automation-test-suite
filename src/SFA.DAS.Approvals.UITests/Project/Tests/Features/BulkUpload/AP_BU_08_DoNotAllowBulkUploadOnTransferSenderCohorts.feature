@approvals
Feature: AP_BU_08_DoNotAllowBulkUploadOnTransferSenderCohorts

@regression
@newBUJourney
Scenario: AP_BU_08_Do Not Allow Bulk Upload On Transfer Sender Cohorts		
	Given the provider has a cohort which is with transfer-sender
	When the provider tries a bulk upload file to add apprentices in that cohort
	Then Transfer Sender Cohorts error message is displayed	