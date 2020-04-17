Feature: RE_CUA_04

@regression
@registration
Scenario: RE_CUA_04_Verify login with an Email address that is pending activation
	When Given an User registers an acount with email but does not activate it
	Then 'Confirm your identity' page is displayed when the User tries to login with the Unactivated credentials