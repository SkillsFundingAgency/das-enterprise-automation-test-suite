Feature: CA_EmployerHub_01

@campaigns
@employer
@regression
Scenario: CA_EmployerHub_01_Check Employer Hub Page Details
	Given the user navigates to the employer page
	Then the links are not broken
	And the video links are not broken
	And the fire it up tile card links are not broken