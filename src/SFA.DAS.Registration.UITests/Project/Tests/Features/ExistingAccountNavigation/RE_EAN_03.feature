Feature: RE_EAN_03

@regression
@registration
@ignore
Scenario: RE_EAN_03_Verify Login for Existing Transactor user
	Given the Employer logins using existing transactor user account
	Then the user can not add an organisation
	And the user can not add Payee Scheme
	And the user can not invite a team members
	And the user can not accept agreement