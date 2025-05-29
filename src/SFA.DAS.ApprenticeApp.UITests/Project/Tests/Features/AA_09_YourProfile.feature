Feature: AA_09_YourProfile

Your profile page is displayed

@ApprenticeApp
@regression
Scenario: AA_09_Your profile page is displayed
	Given the apprentice has logged into the app
	When the apprentice clicks on the account tab
	And the apprentice clicks on your profile
	Then the profile page is displayed
