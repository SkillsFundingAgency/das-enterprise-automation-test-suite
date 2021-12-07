Feature: EI_EC_01_VerifyEarnings

@regression
@employerincentivesphase3
@addlevyfunds
Scenario: EI_EC_01_Apply for Incentive for a New Account with start date as less than 3 months in past and verify Earnings
	Given an Employer creates a Levy Account and Signs the Agreement
	And the Employer adds an apprentice Aged16to24 as of 01AUG2021 with start date in previous month
	And the Provider approves the apprenticeship request
	When the Employer Initiates EI Application journey for Single entity account
	Then the Employer is able to submit the EI Application without submitting bank details
	And Earnings data is populated for the Employer
	And the incentive phase is set to Phase2


@regression
@employerincentivesphase3
@addlevyfunds
Scenario: EI_EC_01_Apply for Incentive for a New Account with start date as more than 3 months in past and verify Earnings
	Given an Employer creates a Levy Account and Signs the Agreement
	And the Employer adds an apprentice Aged16to24 as of 01AUG2021 with start date more than 3 month in past
	And the Provider approves the apprenticeship request
	When the Employer Initiates EI Application journey for Single entity account
	Then the Employer is able to submit the EI Application without submitting bank details
	And Earnings data is populated for the Employer
	And the incentive phase is set to Phase2

@regression
@employerincentives
@addlevyfunds
Scenario: EI_EC_01_Apply for Phase 3 Incentive for a New Account with start date as less than 3 months in past and verify Earnings
	Given an Employer creates a Levy Account and Signs the Agreement
	And the Employer adds an apprentice Aged16to24 as of 01AUG2020 with start date as Month 12 and Year 2021
	And the Provider approves the apprenticeship request
	When the Employer Initiates EI Application journey for Single entity account
	Then the Employer is able to submit the phase 3 EI Application without submitting bank details
	And Earnings data is populated for the Employer
	And the incentive phase is set to Phase3
