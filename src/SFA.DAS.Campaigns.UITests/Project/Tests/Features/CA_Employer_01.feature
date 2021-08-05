Feature: CA_Employer_01

@campaigns
@apprentice
@regression
Scenario: CA_Employer_01_Check Employer Page Details
	Given the user navigates to the employer page
	Then the links are not broken
	And the video links are not broken
	And the fire it up tile card links are not broken
	