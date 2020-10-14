Feature: CA_EMP_01

@campaigns
@employer
@regression
Scenario: CA_EMP_01_Check Real stories Page
	Given the user navigates to employer real stories page
	Then the links are not broken
	And the video links are not broken
	