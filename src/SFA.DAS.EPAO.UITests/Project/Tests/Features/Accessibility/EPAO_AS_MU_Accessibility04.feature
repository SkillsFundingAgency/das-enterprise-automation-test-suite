Feature: EPAO_AS_MU_Accessibility04

@accessibility
@epao
@assessmentservice
@regression
Scenario: EPAO_AS_MU_Accessibility04A - Change another user's permissions
	Given the Manage User is logged into Assessment Service Application
	When the User initiates editing permissions of another user
	Then the User is able to change the permissions



@accessibility
@epao
@assessmentservice
@regression
Scenario: EPAO_AS_MU_Accessibility04B - Invite and Remove a User
	Given the Manage User is logged into Assessment Service Application
	When the User initiates inviting a new user journey
	Then a new User is invited and able to initiate inviting another user
	And the User can remove newly invited user
