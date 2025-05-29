Feature: AA_08_Settings

Settings are displayed

@ApprenticeApp
@regression
Scenario: AA_08_Settings page is displayed
	Given the apprentice has logged into the app
	When the apprentice clicks on the account tab
	And the apprentice clicks on settings
	Then the settings options are displayed
