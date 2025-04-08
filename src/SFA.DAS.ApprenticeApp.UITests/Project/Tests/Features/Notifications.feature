Feature: Notifications

Notifications are displayed

@ApprenticeApp
@regression
Scenario: Notifications are listed
	Given the apprentice has logged into the app
	When the apprentice clicks on the notifications tab
	Then the notifications are displayed
