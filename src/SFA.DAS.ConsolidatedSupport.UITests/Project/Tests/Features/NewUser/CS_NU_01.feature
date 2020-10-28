Feature: CS_NU_01

@regression
@consolidatedsupport
@newuser
Scenario: CS_NU_01_New User can be updated
	Given a new user without contact and organisation details is created
	Then the user contact details can be updated on the Zendesk portal
	And the user organisation details can be updated on Zendesk portal
