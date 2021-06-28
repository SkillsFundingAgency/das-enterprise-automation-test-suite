Feature: EI_TD3_AddCommitmentsToAnExistingAccount

Scenario: EI_TD3_AddCommitmentsToAnExistingAccount
	Given the Employer logins using existing EI Levy Account
	Then the Employer adds 1 apprentices AgedAbove25 as of 01AUG2020 with start date as Month 6 and Year 2021
	And the Provider approves the apprenticeship request