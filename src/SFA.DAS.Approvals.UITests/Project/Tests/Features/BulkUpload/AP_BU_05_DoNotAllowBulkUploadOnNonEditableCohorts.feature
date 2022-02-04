@approvals
Feature: AP_BU_04_DoNotAllowBulkUploadOnNonEditableCohorts

#@regression
@newBUJourney
Scenario: AP_BU_04_Do Not Allow Bulk Upload On Non Editable  Cohorts
	Given the provider has permission to create new cohort
	And the provider has a cohort which is with employer
	When the provider tries a bulk upload file to add apprentices in that cohort
	Then an error message is displaye
	Given the provider has a cohort which is with transfer-sender
	When the provider tries a bulk upload file to add apprentices in that cohort
	Then an error message is displaye
	Given the provider has a cohort as a result of change of party
	When the provider tries a bulk upload file to add apprentices in that cohort
	Then an error message is displaye