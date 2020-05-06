Feature: RE_EA_01

#@regression
@registration
Scenario: RE_EA_01_Verify Login for Existing Levy Account and Navigation to Saved favourites, Help and all Settings pages
	When the Employer logins using existing Levy Account
	Then Employer is able to navigate to all the link under Settings
	And Employer is able to navigate to Your saved favourites Page
	And Employer is able to navigate to Help Page