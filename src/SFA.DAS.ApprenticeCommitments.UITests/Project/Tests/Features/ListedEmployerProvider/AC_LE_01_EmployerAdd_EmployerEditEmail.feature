Feature: AC_LE_01_EmployerAdd_EmployerEditEmail

@apprenticecommitments
@regression
@waitingtostartapprentice
@aslistedemployer
Scenario: AC_LE_01_EmployerAdd_EmployerEditEmail
	Given the Listed Employer has approved apprentice
	And the employer update the email address
	Then the provider can review and approve the changes
	And the apprentice can create account and confirm their details
	And the employer will no longer be able to change the email address