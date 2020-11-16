@approvals
Feature: AP_COE_02_NewEmployerRequestsChange

@regression
@changeOfEmployer
@liveapprentice
Scenario: AP_COE_02_NewEmployerRequestsChange
	Given the provider has an apprentice with stopped status
	When provider sends COE request to new employer
	Then a banner is displayed for provider with a link to "non-editable" cohort
	When new employer rejects the cohort
	Then a banner is displayed for provider with a link to "editable" cohort
	And Provider Approves the Cohort
	And new employer approves the cohort
	And a new live apprenticeship record is created

