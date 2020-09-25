Feature: RE_EAN_03

@regression
@registration
Scenario: RE_EAN_03_Verify Login for Existing Transactor user
	Given the Employer logins using existing transactor user account
	When the user tries to add organisation
	Then the user should be redirected to access denied page 
	When the user tries to add Payee Scheme
	Then the user should be redirected to access denied page 
	When the user tries to invite a team members
	Then the user should be redirected to access denied page 
	When the user tries to accept agreement 
	Then the user should be redirected to access denied page 
	And the user add an apprentices