Feature: EI_TD3_AddCommitmentsToAnExistingAccount

Scenario: EI_TD3_AddCommitmentsToAnExistingAccount
	Given the Employer logins using existing EI Levy Account
	And the Employer adds 2 apprentices AgedAbove25 as of 01AUG2020 with start date as Month 8 and Year 2020
	And the Provider approves the apprenticeship request
	Then the Employer is able to navigate to EI start page for Single entity account