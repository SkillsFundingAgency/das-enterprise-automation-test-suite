Feature: EI_E2E_01_NewLevyAcApplyWithNoVRF

@regression
@addlevyfunds
@employerincentives
Scenario: EI_E2E_01_NewLevyAcApplyWithNoVRF_Apply for Incentive and submit bank details for a New Levy Account with one legal entity
	Given an Employer creates a Levy Account and Signs the Agreement
	And the Employer adds an apprentice Aged16to24 as of 01AUG2020 with start date as Month 4 and Year 2021
	And the Provider approves the apprenticeship request
	When the Employer Initiates EI Application journey for Single entity account
	Then the Employer is able to submit the EI Application without VRF