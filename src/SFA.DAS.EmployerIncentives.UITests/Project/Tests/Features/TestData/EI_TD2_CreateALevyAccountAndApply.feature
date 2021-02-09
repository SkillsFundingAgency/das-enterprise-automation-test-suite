Feature: EI_TD2_CreateALevyAccountAndApply

@addlevyfunds
@dfeuatachieveservice
@eitd2
Scenario: EI_TD2_Create A LevyAccount with Commitments and apply for EI
	Given an Employer creates a Levy Account and Signs the Agreement
	When the Employer adds 1 apprentices Aged16to24 as of 01AUG2020 with start date as Month 2 and Year 2021
	And the Provider approves the apprenticeship request
	Then the Employer is able to navigate to EI start page for Single entity account
	And the Employer is able to submit the EI Application
	When the Employer Initiates EI Application journey for Single entity account again
	Then Select apprentices shutter page is displayed for selecting Yes option in Qualification page
	And the Employer is able to view EI applications