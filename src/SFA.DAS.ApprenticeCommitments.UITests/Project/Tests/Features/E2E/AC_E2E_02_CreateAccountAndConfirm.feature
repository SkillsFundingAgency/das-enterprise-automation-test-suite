Feature: AC_E2E_02_CreateAccountAndConfirm

@apprenticecommitments
@regression
@waitingtostartapprentice
Scenario: AC_E2E_02_CreateAccountAndConfirm
	Given the Employer has approved apprentice
	Then the apprentice can create account
	And the apprentice can confirm apprenticeship