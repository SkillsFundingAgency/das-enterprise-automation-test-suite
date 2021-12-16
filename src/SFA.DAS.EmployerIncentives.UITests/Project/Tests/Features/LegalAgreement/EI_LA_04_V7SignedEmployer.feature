Feature: EI_LA_04_V7SignedEmployer

@regression
@employerincentivesphase3
@deleteincentiveapplication
Scenario: EI_LA_04_V7SignedEmployer_V7 Signed Employer attempts to apply for Commitments starting OCT2021 or over
	Given the Employer logins using existing Version7AgreementUser Account
	When the Employer Initiates EI Application journey for Single entity account
	Then the Employer is able to submit the EI Application without submitting bank details

@regression
@employerincentivesphase3
@deleteincentiveapplication
Scenario: EI_LA_04_V7SignedEmployer_V7 Enters Invalid Employment Start Date
	Given the Employer logins using existing Version7AgreementUser Account
	When the Employer Initiates EI Application journey for Single entity account
	Then the Employer has to cancel the application when an invalid employment start date is entered