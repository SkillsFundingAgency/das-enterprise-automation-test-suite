Feature: EI_TD3_AddCommitmentsToAnExistingAccount

Scenario: EI_TD3_AddCommitmentsToAnExistingAccount
	Given the Employer logins using existing EI Levy Account
	Then the Employer adds 1 apprentices Aged16to24 as of 01AUG2021 with start date as Month 2 and Year 2022
	And the Provider approves the apprenticeship request