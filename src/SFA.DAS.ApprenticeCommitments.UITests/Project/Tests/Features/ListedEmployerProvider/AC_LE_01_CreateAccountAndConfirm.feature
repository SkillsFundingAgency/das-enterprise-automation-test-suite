Feature: AC_LE_01_CreateAccountAndConfirm

@apprenticecommitments
@regression
@waitingtostartapprentice
@aslistedemployer
Scenario: AC_LE_01_CreateAccountAndConfirm
	Given the Listed Employer has approved apprentice
	And the employer update the email address
	Then the provider can review and approve the changes
	Then the apprentice can create account and confirm their details
	And the apprentice can confirm apprenticeship