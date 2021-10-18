Feature: AC_LE_02_CreateAccountAndConfirm_ProviderEditEmail

@apprenticecommitments
@regression
@waitingtostartapprentice
@aslistedemployer
Scenario: AC_LE_02_CreateAccountAndConfirm_ProviderEditEmail
	Given the Listed Employer has approved apprentice
	And the provider update the email address
	Then the Employer can review and approve the changes
	Then the apprentice can create account and confirm their details