Feature: RE_EAN_04

@regression
@registration
@ignore
Scenario: RE_EAN_04_Verify Login for Existing View user
	Given the Employer logins using existing view user account
	Then the user can not add an organisation
	And the user can not add Payee Scheme
	And the user can not invite a team members
	And the user can not accept agreement
	And the user can not add an apprentices	