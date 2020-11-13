Feature: AP_COP_01_Change Of Provider_HappyPath

@changeOfProvider
@liveapprentice
Scenario: AP_COP_01_Change Of Provider_HappyPath
	Given the employer has an apprentice with stopped status
	When employer sends COP request to new provider
	And new provider approves the cohort
	And employer approves the cohort
	Then a new live apprenticeship record is created with new Provider

