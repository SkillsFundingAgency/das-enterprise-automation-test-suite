@approvals
Feature: AP_COP_03_EmployerDeletesTheCohort

@regression
@changeOfProvider
@liveapprentice
Scenario: AP_COP_03_EmployerDeletesTheCohort
	Given the employer has an apprentice with stopped status
	When employer sends COP request to new provider
	And new Provider sends the cohort back to employer to review
	And employer deletes the Cohort
	Then employer can change provider again