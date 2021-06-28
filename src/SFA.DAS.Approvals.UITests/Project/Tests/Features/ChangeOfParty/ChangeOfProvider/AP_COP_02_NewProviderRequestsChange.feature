@approvals
Feature: AP_COP_02_NewProviderRequestsChange

@regression
@changeOfProvider
@liveapprentice
Scenario: AP_COP_02_NewProviderRequestsChange
	Given the employer has an apprentice with stopped status
	When employer sends COP request to new provider
	Then a banner is displayed for employer with a link to "non-editable" cohort
	When new Provider sends the cohort back to employer to review
	Then a banner is displayed for employer with a link to "editable" cohort
	When employer approves the cohort
	And new provider approves the changes
	Then a new live apprenticeship record is created with new Provider
	And Prevent employer from requesting CoP on the original apprenticeship
