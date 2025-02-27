Feature: AppLogin

Apprentice can log into the Apprentice App

@ApprenticeApp
@regression
Scenario: Apprentice logs into the app
	Given the apprentice has accepted the cookies
	When the apprentice logs into the app
	And the apprentice is taken to the welcome page
	Then the apprentice is taken to the tasks page
