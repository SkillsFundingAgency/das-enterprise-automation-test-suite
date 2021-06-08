Feature: EI_LA_02_V5SignedEmployer

@regression
@employerincentives
Scenario: EI_LA_02_V5SignedEmployer_V5 Signed Employer attempts to apply for Commitments starting APR2021 or over
	Given the Employer logins using existing Version5AgreementUser Account
	When the Employer Initiates EI Application journey for version 5 legal agreement account
	Then the Employer is shown the legal agreement shutter page