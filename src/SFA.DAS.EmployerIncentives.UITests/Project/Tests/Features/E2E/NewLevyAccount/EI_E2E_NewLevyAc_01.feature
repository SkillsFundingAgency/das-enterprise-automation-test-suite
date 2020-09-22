Feature: EI_E2E_NewLevyAc_01

@regression
@addpayedetails
@employerincentives
Scenario: EI_E2E_NewLevyAc_01_New Levy Account with one legal entity adds commitments and applies for Incentive
	Given an Employer creates a Levy Account and Signs the Agreement
	And the Employer adds 2 apprentices Aged16to24 as of 01AUG2020 with start date as Month 10 and Year 2020
	And the Provider approves the apprenticeship request
	When the Employer Initiates EI Application journey for Single entity account