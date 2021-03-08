Feature: EI_LA_01_V4SignedEmployer

@regression
@employerincentives

Scenario: EI_LA_01_V4SignedEmployer_V4 Signed Employer attempts to apply for Commitments starting FEB2021 or over
	Given the Employer logins using existing Version4AgreementUser Account
	When the Employer Initiates EI Application journey for version 4 legal agreement account
	Then the Employer is shown the legal agreement shutter page