Feature: AC_LE_01_CreateAccountAndConfirm_EmployerEditEmail

@apprenticecommitments
@regression
@waitingtostartapprentice
@aslistedemployer
Scenario: AC_LE_01_CreateAccountAndConfirm_EmployerEditEmail
	Given the Listed Employer has approved apprentice
	And the employer update the email address
	Then the provider can review and approve the changes
	Then the apprentice can create account and confirm their details