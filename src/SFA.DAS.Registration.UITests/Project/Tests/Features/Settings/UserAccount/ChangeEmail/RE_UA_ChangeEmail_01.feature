Feature: RE_UA_ChangeEmail_01

@regression
@registration
Scenario: RE_UA_ChangeEmail_01_Verify change Email feature for an User Account
	When an User Account is created
	Then the User is able to change the registered Email