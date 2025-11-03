Feature: AA_05_Notifications

Notifications are displayed

@ApprenticeApp
@regression
Scenario: AA_05_Notifications are listed
	Given the apprentice has logged into the app
	When the apprentice clicks on the notifications tab
	Then the notifications are displayed
