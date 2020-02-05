Feature: RE_EA_01

@regression
@registration
Scenario: RE_EA_01_Verify Login for Existing Levy Account
	Given the Employer login using existing levy account
	Then I will land in the User Home page