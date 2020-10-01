Feature: EI_TD2_AddCommitmentsToAnExistingAccount

Scenario: EI_TD2_AddCommitmentsToAnExistingAccount
	Given the Employer logins using existing EI Levy Account
	And the Employer adds 5 apprentices AgedAbove25 as of 01AUG2020 with start date as Month 1 and Year 2021
	And the Provider approves the apprenticeship request
	Then the Employer is able to navigate to EI start page for Single entity account