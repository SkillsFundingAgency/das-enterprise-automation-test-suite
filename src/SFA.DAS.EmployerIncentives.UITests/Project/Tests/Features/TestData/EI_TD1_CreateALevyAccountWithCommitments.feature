Feature: EI_TD1_CreateALevyAccountWithCommitments

@addlevyfunds
@eitd1a
Scenario: EI_TD1_A_Create A LevyAccount and add 2 Commitments
	Given an Employer creates a Levy Account and Signs the Agreement
	And the employer signs the agreement version 7
	Then the Employer adds 2 apprentices AgedAbove25 as of 01AUG2021 with start date as Month 11 and Year 2021
	And the Provider approves the apprenticeship request

@addlevyfunds
@eitd1b
Scenario: EI_TD1_B_Create A LevyAccount and add 10 Commitments
	Given an Employer creates a Levy Account and Signs the Agreement
	And the employer signs the agreement version 7
	Then the Employer adds 10 apprentices AgedAbove25 as of 01AUG2021 with start date as Month 11 and Year 2021
	And the Provider approves the apprenticeship request

	@addlevyfunds
@eitd1a
Scenario: EI_TD1_C_TestDataPreparation-For_EI_E2E_04_ExistingLevyAcApplyWithVRFAndWithdraw
	Given an Employer creates a Levy Account and Signs the Agreement
	And the employer signs the agreement version 7
	Then the Employer adds 2 apprentices Aged16to24 as of 01AUG2021 with start date as Month 2 and Year 2022
	And the Provider approves the apprenticeship request