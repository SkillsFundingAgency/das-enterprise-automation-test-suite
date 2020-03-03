Feature: CA_AP_01

@campaigns
@apprentice
@regression
Scenario: CA_AP_01_Check Real stories Page Details
	Given the user navigates to the real stories page
	Then the links are not broken
	And the video links are not broken
