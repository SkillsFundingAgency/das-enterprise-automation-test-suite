Feature: AC_CD_02_ConfirmEmployerDetailsAsIncorrect

@apprenticecommitments
@regression
@deleteuser
Scenario: AC_CD_02_ConfirmEmployerDetailsAsIncorrect
	Given an apprentice has created and validated the account
	Then the apprentice confirms the Employer details displayed as Incorrect
	And  the apprentice is able to confirm the Employer details again as correct 