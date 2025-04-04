Feature: YourProfile

Your profile page is displayed

@ApprenticeApp
@regression
Scenario: Your profile page is displayed
	Given the apprentice has logged into the app
	When the apprentice user clicks on the account tab
	And the apprentice user clicks on your profile
	Then the profile page is displayed
