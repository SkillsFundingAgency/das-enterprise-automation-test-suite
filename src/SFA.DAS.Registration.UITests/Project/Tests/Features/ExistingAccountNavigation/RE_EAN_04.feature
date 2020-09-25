Feature: RE_EAN_04

@regression
@registration
Scenario: RE_EAN_04_Verify Login for Existing View user
	Given the Employer logins using existing view user account
	When the user tries to add organisation
	Then the user should be redirected to access denied page 
	When the user tries to add Payee Scheme
	Then the user should be redirected to access denied page 
	When the user tries to invite a team members
	Then the user should be redirected to access denied page 
	When the user tries to accept agreement 
	Then the user should be redirected to access denied page 
	And the user add an apprentices