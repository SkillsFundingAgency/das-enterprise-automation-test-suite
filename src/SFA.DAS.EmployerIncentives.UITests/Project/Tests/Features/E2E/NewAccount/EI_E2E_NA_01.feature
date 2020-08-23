Feature: EI_E2E_NA_01

@regression
@addpayedetails
@employerincentives
Scenario: EI_E2E_NA_01_New Levy Account with one legal entity adds commitments and applies for Incentive
	Given an Employer creates a Levy Account and Signs the Agreement
	And the Employer adds 2 apprentices AgedAbove25 as of 01AUG2020 with start date as Month 10 and Year 2020
	When the Employer Initiates EI Application journey for Single entity account
	#Then the Employer is able to submit EI application