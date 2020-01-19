Feature: AS_MU_02

@epao
@assessmentservice
@regression
Scenario: AS_MU_02 - Invite and Remove a User
	Given the Manage User is logged into Assessment Service Application
	When the User initiates inviting a new user journey
	Then a new User is invited and able to initiate inviting another user
	And the User can remove newly invited user