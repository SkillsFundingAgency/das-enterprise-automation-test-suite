@approvals
Feature: AP_BU_09_DoNotAllowBulkUploadOnChangeOfPartyCohorts

@regression
@newBUJourney
Scenario: AP_BU_09_Do Not Allow Bulk Upload On Change Of Party Cohorts		
	Given the provider has a cohort as a result of change of party
	When the provider tries a bulk upload file to add apprentices in that cohort
	Then an error message is displayed