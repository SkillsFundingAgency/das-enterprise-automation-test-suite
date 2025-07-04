Feature: FAA_DA_02

@raa
@regression
@raaprovider
@faa
Scenario: FAA_DA_02 - Submitted Application Is Withdrawn On Account Deletion
	Given appretince creates an account
	When the apprentice has submitted their first application
	Then the apprentice attempts to delete their account they are notified of application withdrawal
