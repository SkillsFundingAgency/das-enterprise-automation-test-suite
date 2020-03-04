Feature: CA_AP_06

@campaigns
@apprentice
@regression
Scenario: CA_AP_06_Check Your Apprenticeship Page Details
	Given the user navigates to the your apprenticeship page
	Then the links are not broken
	And the video links are not broken
