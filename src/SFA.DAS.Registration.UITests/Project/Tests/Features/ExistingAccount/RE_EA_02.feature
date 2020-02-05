Feature: RE_EA_02

@regression
@registration
Scenario: RE_EA_02_Verify Login for Existing NonLevy Account
	Given the Employer login using existing non levy account
	Then I will land in the User Home page