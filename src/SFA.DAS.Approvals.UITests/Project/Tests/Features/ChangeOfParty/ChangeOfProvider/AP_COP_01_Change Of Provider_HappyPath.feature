@approvals
Feature: AP_COP_01_Change Of Provider_HappyPath

@regression
@changeOfProvider
@liveapprentice
Scenario: AP_COP_01_Change Of Provider_HappyPath
	Given the employer has an apprentice with stopped status
	When employer sends COP request to new provider
	Then employer should not be able to see change link for another CoP
	When new provider approves the cohort
	And employer approves the cohort
	Then a new live apprenticeship record is created with new Provider
	And Employer can only edit start date, end date and Price on the new record

