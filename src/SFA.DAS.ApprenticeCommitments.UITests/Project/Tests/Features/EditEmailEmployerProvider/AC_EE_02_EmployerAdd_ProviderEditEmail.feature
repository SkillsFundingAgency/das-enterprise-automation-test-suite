Feature: AC_EE_02_EmployerAdd_ProviderEditEmail

@apprenticecommitments
@regression
@liveapprentice
@aslistedemployer
Scenario: AC_EE_02_EmployerAdd_ProviderEditEmail
	Given the listed employer has approved apprentice
	And the provider update the email address
	Then the employer can review and approve the changes
	And the apprentice can create account and confirm their details
	And the provider will no longer be able to change the email address