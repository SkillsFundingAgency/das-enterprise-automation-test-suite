@approvals
Feature: AP_COE_01_HappyPath

@regression
@changeOfEmployer
@liveapprentice
Scenario: AP_COE_01_Change Of Employer_HappyPath
	Given the provider has an apprentice with stopped status
	When provider sends COE request to new employer
	And Validate that old Employer cannot request CoP during in-flight CoE
	And new employer approves the cohort
	Then a new live apprenticeship record is created
	And Validate that old Employer cannot request CoP after successful CoE