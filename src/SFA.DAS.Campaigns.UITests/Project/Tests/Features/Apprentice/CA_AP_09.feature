Feature: CA_AP_09

@campaigns
@apprentice
@regression
Scenario: CA_AP_09 Check Become An Apprentice Page Details
	Given the user navigates to Become An Apprentice page
	Then the apprentice sub headings are displayed
	Then the links are not broken