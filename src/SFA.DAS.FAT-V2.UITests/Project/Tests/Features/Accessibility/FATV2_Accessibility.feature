Feature: FATV2_Accessibility

@fatv2
@accessibility
Scenario: FATV2_Accessibility_TEST
	Given the user has shortlisted a provider
	When the the user navigates to shortlist page
	Then the user is able remove the shortlisted provider
	And the user is able to return to course search page