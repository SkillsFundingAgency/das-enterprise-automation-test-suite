@approvals
Feature: AP_COE_03_ProviderDeletesTheCohort

@regression
@changeOfEmployer
Scenario: AP_COE_03_ProviderDeletesTheCohort
	Given the provider has an apprentice with stopped status
	When provider sends COE request to new employer
	And new employer rejects the cohort
	And Provider deletes the Cohort
	Then provider can change employer again