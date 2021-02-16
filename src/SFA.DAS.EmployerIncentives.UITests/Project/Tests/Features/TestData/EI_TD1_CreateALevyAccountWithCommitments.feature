Feature: EI_TD1_CreateALevyAccountWithCommitments

@addlevyfunds
@eitd1
Scenario: EI_TD1_Create A LevyAccount and add some Commitments
	Given an Employer creates a Levy Account and Signs the Agreement
	Then the Employer adds 2 apprentices AgedAbove25 as of 01AUG2020 with start date as Month 2 and Year 2021
	And the Provider approves the apprenticeship request