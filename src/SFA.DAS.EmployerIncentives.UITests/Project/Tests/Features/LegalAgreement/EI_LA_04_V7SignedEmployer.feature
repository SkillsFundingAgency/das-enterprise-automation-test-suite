Feature: EI_LA_04_V7SignedEmployer

@regression
@employerincentivesphase3
Scenario: EI_LA_04_V7SignedEmployer_V7 Signed Employer attempts to apply for Commitments starting APR2021 or over
	Given the Employer logins using existing Version7AgreementUser Account
	Given the Employer adds an apprentice Aged16to24 as of 01AUG2021 with start date as Month 11 and Year 2021
	And the Provider approves the apprenticeship request
	When the Employer Initiates EI Application journey for Single entity account
	Then the Employer is able to submit the EI Application without submitting bank details