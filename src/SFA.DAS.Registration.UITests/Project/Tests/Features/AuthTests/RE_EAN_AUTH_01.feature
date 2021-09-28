Feature: RE_EAN_AUTH_01

@authtests
@regression
@registration
Scenario: RE_EAN_AUTH_01_Verify Login for Existing Levy Account and Navigation to Saved favourites, Help and all Settings pages
	When the Employer logins using existing Levy Account
	Then Employer is able to navigate to all the link under Settings
	And a valid user can not access different account
	And an unauthorised user can not access the service
	