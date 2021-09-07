Feature: CA_AP_01

@campaigns
@apprentice
@regression
@captureurl
Scenario: CA_AP_01_Check Browse Apprenticeship Page And Search For An Apprenticeship
	Given the user navigates to the browse apprenticeship page
	Then the links are not broken
	And the user can search for an apprenticeship