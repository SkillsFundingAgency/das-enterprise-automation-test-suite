Feature: AC_RP_01_ForgottenPwdFromSignInPageForPersonalDetailsPendingAccount

@apprenticecommitments
@regression
@deletecmaddatacreatedthroughapi
Scenario: AC_RP_01_ForgottenPwdFromSignInPageForPersonalDetailsPendingAccount
	When an apprentice submits Email to reset password for a new account pending personal details confirmation
	Then the apprentice is able to reset the password using the invitation