Feature: Settings

Settings are displayed

@ApprenticeApp
@regression
Scenario: Settings page is displayed
	Given the apprentice has logged into the app
	When the apprentice user clicks on the account tab
	And the apprentice user clicks on settings
	Then the settings options are displayed
