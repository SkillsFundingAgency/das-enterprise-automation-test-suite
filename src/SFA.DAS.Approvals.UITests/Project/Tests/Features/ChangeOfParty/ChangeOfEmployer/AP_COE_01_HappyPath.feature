@approvals
Feature: AP_COE_01_HappyPath

@regression
@changeOfEmployer
@liveapprentice
Scenario: AP_COE_01_Change Of Employer_HappyPath
	Given the provider has an apprentice with stopped status
	When provider sends COE request to new employer
	And new employer approves the cohort
	Then a new live apprenticeship record is created 