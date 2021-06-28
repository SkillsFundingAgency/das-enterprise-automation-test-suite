Feature: AC_CD_06_ConfirmApprenticeshipDetailsAsIncorrect

@apprenticecommitments
@regression
@deleteuser
Scenario: AC_CD_06_ConfirmApprenticeshipDetailsAsIncorrect
	Given an apprentice has created and validated the account
	Then the apprentice confirms the Apprenticeship details displayed as Incorrect
	And the apprentice is able to confirm the Apprenticeship details again as correct