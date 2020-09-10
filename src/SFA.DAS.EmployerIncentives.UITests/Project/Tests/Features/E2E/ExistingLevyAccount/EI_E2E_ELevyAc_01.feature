Feature: EI_E2E_ELevyAc_01

@regression
@employerincentives
Scenario: EI_E2E_ELevyAc_01_Existing Levy Account with one legal entity adds commitments and applies for Incentive
	Given the Employer logins using existing EI Levy Account
	And the Employer adds 2 apprentices AgedAbove25 as of 01AUG2020 with start date as Month 9 and Year 2020
	And the Provider approves the apprenticeship request
	When the Employer Initiates EI Application journey for Single entity account