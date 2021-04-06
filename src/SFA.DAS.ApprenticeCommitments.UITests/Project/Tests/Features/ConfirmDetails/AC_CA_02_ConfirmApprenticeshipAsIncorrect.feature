Feature: AC_CA_02_ConfirmApprenticeshipAsIncorrect

@apprenticecommitments
@regression
@deleteuser
Scenario: AC_CA_02_ConfirmApprenticeshipAsIncorrect
	Given an apprentice has created and validated the account
	Then the apprentice confirms the Apprenticeship details displayed as Incorrect