Feature: EI_LA_02_V5SignedEmployer

@regression
@employerincentives

Scenario: EI_LA_02_V5SignedEmployer_V5 Signed Employer attempts to apply for Commitments starting FEB2021 or over
	Given the Employer logins using existing Version5AgreementUser Account
	And the Employer adds an apprentice Aged16to24 as of 01AUG2020 with start date as Month 2 and Year 2021
	And the Provider approves the apprenticeship request
	When the Employer Initiates EI Application journey for Single entity account
	Then the Employer is able to submit the EI Application without submitting bank details