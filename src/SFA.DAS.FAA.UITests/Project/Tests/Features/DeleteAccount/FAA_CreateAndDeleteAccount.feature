Feature: FAA_CreateAndDeleteAccount


@raa
@regression
@faa
@raaprovider
Scenario: FAA_CreateAndDeleteAccount
	Given appretince creates an account
	Then apprentice is able to delete account
