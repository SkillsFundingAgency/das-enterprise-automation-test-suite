Feature: CS_NU_01

@regression
@consolidatedsupport
@newuser
Scenario: CS_NU_01_New User can be updated
	Given A new user is created 
	Then the user can be updated
	And an organisation can be associated
