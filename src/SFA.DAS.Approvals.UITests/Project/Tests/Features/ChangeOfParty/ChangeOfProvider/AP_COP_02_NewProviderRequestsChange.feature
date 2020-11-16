Feature: AP_COP_02_NewProviderRequestsChange

@changeOfProvider
@liveapprentice
Scenario: AP_COP_02_NewProviderRequestsChange
	Given the employer has an apprentice with stopped status
	When employer sends COP request to new provider
	Then a banner is displayed for employer with a link to "non-editable" cohort
	When new provider rejects the cohort
	Then a banner is displayed for employer with a link to "editable" cohort
	When employer approves the cohort
	And new provider approves the cohort
	Then a new live apprenticeship record is created with new Provider
