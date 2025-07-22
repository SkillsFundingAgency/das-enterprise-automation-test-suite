Feature: AA_07_Support and Guidance

Support and guidance articles are displayed

@ApprenticeApp
@regression
Scenario: AA_07_Support and guidance articles are listed
	Given the apprentice has logged into the app
	When the apprentice clicks on the support and guidance tab
	Then the support and guidance articles are displayed
