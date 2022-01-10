Feature: EI_LA_03_V6SignedEmployer

@regression
@employerincentives
Scenario: EI_LA_03_V6SignedEmployer_V6 Signed Employer attempts to apply for Commitments starting OCT2021 or over
	Given the Employer logins using existing Version6AgreementUser Account
	When the Employer Initiates EI Application journey for version 6 legal agreement account
	Then the Employer is shown the legal agreement shutter page