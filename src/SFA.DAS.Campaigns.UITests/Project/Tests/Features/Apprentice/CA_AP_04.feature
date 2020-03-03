Feature: CA_AP_04

@campaigns
@apprentice
@regression
Scenario: CA_AP_04_Check Application Page Details
	Given the user navigates to the application page
	Then the links are not broken
	And the video links are not broken
