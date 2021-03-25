Feature: EI_E2E_NewLevyAcApplyWithVRFAndAmendVRF

@regression
@addlevyfunds
@employerincentives
@vrfservice
Scenario: EI_E2E_NewLevyAcApplyWithVRFAndAmendVRF_Apply for Incentive, Submit and Amend bank details for a New Levy Account
	Given an Employer creates a Levy Account and Signs the Agreement
	And the Employer adds an apprentice Aged16to24 as of 01AUG2020 with start date as Month 9 and Year 2020
	And the Provider approves the apprenticeship request
	When the Employer Initiates EI Application journey for Single entity account
	Then the Employer is able to submit the EI Application
	When the Employer Initiates EI Application journey for Single entity account again
	Then Select apprentices shutter page is displayed for selecting Yes option in Qualification page
	And the Employer is able to view EI applications
	When the Application Case details are changed to completed status
	Then the Employer is able to Amend bank details