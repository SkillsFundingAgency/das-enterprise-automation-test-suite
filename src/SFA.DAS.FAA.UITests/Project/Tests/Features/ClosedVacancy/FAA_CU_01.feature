Feature: FAA_CU_01

@raa
@regression
@faa
Scenario: FAA_CU_01 - Logged in user is able to view closed vacancy
	Given the apprentice can navigate to a closed vacancy URL
	Then the candidate can login in to FAA from closed vacancy page

