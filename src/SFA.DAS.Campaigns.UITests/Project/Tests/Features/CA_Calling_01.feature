Feature: CA_Calling_01

@campaigns
@apprentice
@regression
Scenario: CA_Calling_01_Check The Calling Page Details
	Given the user can navigate to the calling page
	Then the links are not broken
	And the video links are not broken
