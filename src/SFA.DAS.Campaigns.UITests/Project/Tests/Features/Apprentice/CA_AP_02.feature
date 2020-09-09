Feature: CA_AP_02

@campaigns
@apprentice
@regression
Scenario: CA_AP_02_Check The Benefits Of Apprenticeships Page Details
	Given the user navigates to the benefits of apprenticeship page
	Then the links are not broken
	#And the video links are not broken
