Feature: CA_AP_05

@campaigns
@apprentice
@regression
Scenario: CA_AP_05_Check Interview Page Details
	Given the user navigates to the interview page
	Then the links are not broken
	And the video links are not broken
