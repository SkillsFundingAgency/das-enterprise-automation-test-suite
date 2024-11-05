Feature: FAA_DeleteAccount


@raa
@regression
@faa
Scenario: FAA_DeleteAccount - User deletes an account
	Given appretince creates an account
	Then apprentice is able to delete account
