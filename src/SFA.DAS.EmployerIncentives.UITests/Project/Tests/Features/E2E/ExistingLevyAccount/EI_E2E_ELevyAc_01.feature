Feature: EI_E2E_ELevyAc_01

@regression
@employerincentives
@loginintodfeuatachieveservice
Scenario: EI_E2E_ELevyAc_01_Existing Levy Account with one legal entity adds commitments and applies for Incentive
	Given the Employer logins using existing EI Levy Account
	When the Employer Initiates EI Application journey for Single entity account
	And the Employer submits the EI Application
	And the Employer submits organisation bank details 