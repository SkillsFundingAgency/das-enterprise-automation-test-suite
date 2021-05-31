Feature: EI_EC_01_VerifyEarnings

@regression
@employerincentives
@addlevyfunds
Scenario: EI_EC_01_Apply for Incentive for a New Account and verify Earnings
	Given an Employer creates a Levy Account and Signs the Agreement
	And the Employer adds an apprentice Aged16to24 as of 01AUG2020 with start date as Month 5 and Year 2021
	And the Provider approves the apprenticeship request
	When the Employer Initiates EI Application journey for Single entity account
	Then the Employer is able to submit the EI Application without submitting bank details
	And Earnings data is populated for the Employer