Feature: EPAO_AS_OD_01

@epao
@assessmentservice
@regression
Scenario: EPAO_AS_OD_01 - Update organisation details
	Given the Manage User is logged into Assessment Service Application
	When the User navigates to Organisation details page
	Then the User is able to change the Registered details