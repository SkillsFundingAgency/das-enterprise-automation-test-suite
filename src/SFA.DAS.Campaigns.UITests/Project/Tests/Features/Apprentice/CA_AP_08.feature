Feature: CA_AP_08


@campaigns
@apprentice
@regression
Scenario: CA_AP_08_Check Find An Apprenticeship Page Details And Search For An Apprenticeship
	Given the user navigates to the find an apprenticeship page
	Then the links are not broken
	And the video links are not broken
	And the user can search for an apprenticeship
