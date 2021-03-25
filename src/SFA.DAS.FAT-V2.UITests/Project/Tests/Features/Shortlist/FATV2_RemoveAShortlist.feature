Feature: FATV2_RemoveAShortlist

@mytag
Scenario: FATV2_RAC_01_Remove A Shortlisted Provider
	Given the user has shortlisted a provider
	When the the user navigates to shortlist page
	Then the user is able remove the shortlisted provider
	And the user is able to return to course search page