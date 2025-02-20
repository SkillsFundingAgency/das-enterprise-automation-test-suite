Feature: AppLogin

Apprentice can log into the Apprentice App

@ApprenticeApp
@regression
Scenario: Apprentice logs into the app
	Given the apprentice has logged into the app
	Then the apprentice is taken to the home screen
