Feature: AA_02_YourProfile

Your profile page is displayed

@ApprenticeApp
@regression
Scenario: AA_02_Your profile page is displayed
	Given the apprentice has logged into the app
	When the apprentice clicks on the account tab
	And the apprentice clicks on your profile
	Then the profile page is displayed
