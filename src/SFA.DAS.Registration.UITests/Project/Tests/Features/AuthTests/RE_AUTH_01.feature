Feature: RE_AUTH_01

@authtests
Scenario: RE_Auth_01_Verify Auth for existing Levy Account 
	When the Employer logins using existing Levy Account
	Then Employer is able to navigate to all the link under Settings
	Then UnAuthorised users can not access the service