Feature: RE_CUA_02

@regression
@registration
Scenario: RE_CUA_02_Verify registering an account with e-mail address that is already associated to an Active Account
	When an User tries to regiser an Account with email an e-mail already registered
	Then 'Email already regisered' message is shown to the User