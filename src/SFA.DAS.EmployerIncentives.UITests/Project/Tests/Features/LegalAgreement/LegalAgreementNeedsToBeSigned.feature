Feature: LegalAgreementNeedsToBeSigned

@regression
@employerincentives

Scenario: Employer has signed previous legal agreement
	Given the Employer logins using existing Version4AgreementUser Account
	And the Employer adds an apprentice Aged16to24 as of 01AUG2020 with start date as Month 2 and Year 2021
	And the Provider approves the apprenticeship request
	When the Employer Initiates EI Application journey for version 4 legal agreement account
	Then the Employer is shown the legal agreement shutter page