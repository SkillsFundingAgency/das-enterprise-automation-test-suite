Feature: EI_TD1_CreateALevyAccountWithCommitments

@addlevyfunds
@eitd1
Scenario: EI_TD1_Create A LevyAccount and add some Commitments
	Given an Employer creates a Levy Account and Signs the Agreement
	Then the Employer adds 2 apprentices Aged16to24 as of 01AUG2020 with start date as Month 8 and Year 2020
	And the Provider approves the apprenticeship request