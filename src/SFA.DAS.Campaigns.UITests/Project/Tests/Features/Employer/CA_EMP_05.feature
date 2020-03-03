Feature: CA_EMP_05

@campaigns
@apprentice
@regression
Scenario: CA_EMP_05_Check End Point Assessments Page Details
	Given the user navigates to the end point assessments page
	Then the links are not broken
	And the video links are not broken
