Feature: CS_NU_01

New User's contact and organisation details can be updated
So that Zendesk can interact with Service Now Platform.

@regression
@consolidatedsupport
@newuser
Scenario: CS_NU_01_New User contact and organisation details can be updated
	Given a new user without contact and organisation details is created
	Then the user contact details can be updated on the Zendesk portal
	And the user organisation details can be updated on Zendesk portal
