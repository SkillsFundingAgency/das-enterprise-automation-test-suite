Feature: EI_E2E_EA_01

@regression
@employerincentives
Scenario: EI_E2E_EA_01_Existing Levy Account with one legal entity adds commitments and applies for Incentive
	Given the Employer logins using existing Levy Account
	And the Employer adds 2 apprentices Aged16to24 as of 01AUG2020 with start date as Month 8 and Year 2020
	When the Employer Initiates EI Application journey for Single entity account
	#Then the Employer is able to submit EI application