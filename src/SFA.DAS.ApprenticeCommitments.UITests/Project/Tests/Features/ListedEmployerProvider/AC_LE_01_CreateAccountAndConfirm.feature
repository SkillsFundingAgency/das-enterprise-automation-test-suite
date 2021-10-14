Feature: AC_LE_01_CreateAccountAndConfirm

@apprenticecommitments
@regression
@waitingtostartapprentice
@aslistedemployer
Scenario: AC_LE_01_CreateAccountAndConfirm
	Given the Listed Employer has approved apprentice
	Then the apprentice can create account
	And the apprentice can confirm apprenticeship