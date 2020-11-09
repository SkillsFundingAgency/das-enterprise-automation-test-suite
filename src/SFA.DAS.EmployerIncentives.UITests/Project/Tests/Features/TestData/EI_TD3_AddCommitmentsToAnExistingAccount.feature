Feature: EI_TD3_AddCommitmentsToAnExistingAccount

@dfeuatachieveservice
Scenario: EI_TD3_AddCommitmentsToAnExistingAccount
	Given the Employer logins using existing EI Levy Account
	And the Employer adds 2 apprentices AgedAbove25 as of 01AUG2020 with start date as Month 9 and Year 2020
	And the Provider approves the apprenticeship request
	Then the Employer is able to navigate to EI start page for Single entity account
	And the Employer is able to submit the EI Application
	When the Employer Initiates EI Application journey for Single entity account again
	Then Select apprentices shutter page is displayed for selecting Yes option in Qualification page