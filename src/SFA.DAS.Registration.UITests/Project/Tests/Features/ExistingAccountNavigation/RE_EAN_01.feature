Feature: RE_EAN_01

@regression
@registration
Scenario: RE_EAN_01_Verify Login for Existing Levy Account and Navigation to Saved favourites, Help and all Settings pages
	When the Employer logins using existing Levy Account
	Then Employer is able to navigate to all the link under Settings
	And Employer is able to navigate to Help Page