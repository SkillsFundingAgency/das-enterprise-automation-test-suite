Feature: AP_COE_01_HappyPath

@mytag
Scenario: Change Of Employer
	Given the provider has an apprentice with a stopped status
	When provider sends COE request to new employer
	And new employer aproves the cohort
	Then a new live apprenticeship record is created 
