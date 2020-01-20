Feature: AS_MU_01

@epao
@assessmentservice
@regression
Scenario: AS_MU_01 - Change another user's permissions
	Given the Manage User is logged into Assessment Service Application
	When the User initiates editing permissions of another user
	Then the User is able to change the permissions