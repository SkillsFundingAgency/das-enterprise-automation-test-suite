Feature: EI_TD1_CreateALevyAccountWithCommitments

@addlevyfunds
@eitd1a
Scenario: EI_TD1_A_Create A LevyAccount and add 2 Commitments
	Given an Employer creates a Levy Account and Signs the Agreement
	Then the Employer adds 2 apprentices AgedAbove25 as of 01AUG2020 with start date as Month 5 and Year 2021
	And the Provider approves the apprenticeship request

@addlevyfunds
@eitd1b
Scenario: EI_TD1_B_Create A LevyAccount and add 10 Commitments
	Given an Employer creates a Levy Account and Signs the Agreement
	Then the Employer adds 10 apprentices AgedAbove25 as of 01AUG2020 with start date as Month 5 and Year 2021
	And the Provider approves the apprenticeship request