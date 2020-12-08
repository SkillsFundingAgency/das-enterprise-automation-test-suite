Feature: RE_CUA_02

@regression
@registration
@addnonlevyfunds
Scenario: RE_CUA_02_Verify registering an account with an Email address that is pending activation by another User
	When Given an User registers an acount with email but does not activate it
	And the User tries to regiser another Account with the same Email that is pending activation
	Then the User is allowed to activate the account and continue with registration