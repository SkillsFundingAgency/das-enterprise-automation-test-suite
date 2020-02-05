Feature: RE_EA_01

@regression
@registration
Scenario: RE_EA_01_Verify Login for Existing Levy Account
	Given the Employer logins using existing Levy Account
	Then the Employer Home page is displayed