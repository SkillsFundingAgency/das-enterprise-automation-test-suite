Feature: RV1_MR_01

@raa-v1
@regression
Scenario: RV1_MR_01 - Verify Manage Helpdesk adviser role functionality
	Given the reviewer logged in to the manage application
	And switches the role to helpdesk adviser
	Then the reviewer is able to search and select a candidate
	And view the candidate's applications