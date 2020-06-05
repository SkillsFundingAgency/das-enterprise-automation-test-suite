Feature: RE_EA_02

@regression
@registration
Scenario: RE_EA_02_Verify Login for Existing NonLevy Account
	When the Employer logins using existing NonLevy Account
	Then the Employer Home page is displayed