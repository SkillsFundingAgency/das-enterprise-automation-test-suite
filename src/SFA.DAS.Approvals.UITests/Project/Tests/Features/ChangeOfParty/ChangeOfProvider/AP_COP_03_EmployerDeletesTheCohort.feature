@approvals
Feature: AP_COP_03_EmployerDeletesTheCohort

@changeOfProvider
@liveapprentice
Scenario: AP_COP_03_EmployerDeletesTheCohort
	Given the employer has an apprentice with stopped status
	When employer sends COP request to new provider
	And new provider rejects the cohort
	And employer deletes the Cohort
	Then employer can change provider again