Feature: AC_LE_01_CreateAccountAndConfirm

@apprenticecommitments
@regression
@waitingtostartapprentice
@aslistedemployer
Scenario: AC_LE_01_CreateAccountAndConfirm
	Given the Listed Employer has approved apprentice
	And the employer update the email address
	Then the apprentice can create account
	And the apprentice can confirm apprenticeship