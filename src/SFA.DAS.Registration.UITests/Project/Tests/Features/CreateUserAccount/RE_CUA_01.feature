Feature: RE_CUA_01

@regression
@registration
Scenario: RE_CUA_01_Verify registering an account with an Email address that is already associated to an Active Account
	When an User tries to regiser an Account with an Email already registered
	Then 'Email already regisered' message is shown to the User