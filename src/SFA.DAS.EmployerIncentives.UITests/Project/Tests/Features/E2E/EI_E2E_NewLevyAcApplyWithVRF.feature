Feature: EI_E2E_NewLevyAcApplyWithVRF

@regression
@addlevyfunds
@employerincentives
@dfeuatachieveservice
Scenario: EI_E2E_NewLevyAcApplyWithVRF_Apply for Incentive and submit bank details for a New Levy Account with one legal entity
	Given an Employer creates a Levy Account and Signs the Agreement
	And the Employer adds an apprentice Aged16to24 as of 01AUG2020 with start date as Month 9 and Year 2020
	And the Provider approves the apprenticeship request
	When the Employer Initiates EI Application journey for Single entity account
	Then the Employer is able to submit the EI Application
	When the Employer Initiates EI Application journey for Single entity account again
	Then Select apprentices shutter page is displayed for selecting Yes option in Qualification page
	And the Employer is able to view EI applications