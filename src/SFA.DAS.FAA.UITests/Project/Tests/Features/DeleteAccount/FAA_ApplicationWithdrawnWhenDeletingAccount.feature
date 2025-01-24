Feature: FAA_DA_02
A short summary of the feature

@raa
@regression
@faa
Scenario: FAA_DA_02 - Submitted Application Is Withdrawn On Account Deletion
	Given appretince creates an account
	And the apprentice has submitted their first application
	When the apprentice attempts to delete their account
	Then the apprentice is notified that the submitted application will be withdrawn
