Feature: Settings

Settings are displayed

@ApprenticeApp
@regression
Scenario: Settings page is displayed
	Given the apprentice has logged into the app
	When the apprentice clicks on the account tab
	And the apprentice clicks on settings
	Then the settings options are displayed
