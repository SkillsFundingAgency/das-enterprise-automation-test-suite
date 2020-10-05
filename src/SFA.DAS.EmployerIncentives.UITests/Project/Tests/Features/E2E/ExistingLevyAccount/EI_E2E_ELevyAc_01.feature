Feature: EI_E2E_ELevyAc_01

@regression
@employerincentives
@dfeuatachieveservice
Scenario: EI_E2E_ELevyAc_01_Existing Levy Account with one legal entity adds commitments and applies for Incentive
	Given the Employer logins using existing EI Levy Account
	When the Employer Initiates EI Application journey for Single entity account
	Then the Employer is able to submit the EI Application
	When the Employer Initiates EI Application journey for Single entity account again
	Then Select apprentices shutter page is displayed for selecting Yes option in Qualification page
	And the Employer is able to navigate to View Applications page