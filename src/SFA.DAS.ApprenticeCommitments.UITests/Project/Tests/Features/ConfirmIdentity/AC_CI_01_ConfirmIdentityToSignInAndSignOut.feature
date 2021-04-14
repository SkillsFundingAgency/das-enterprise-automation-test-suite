Feature: AC_CI_01_ConfirmIdentityToSignInAndSignOut

@apprenticecommitments
@regression
@deleteuser
Scenario: AC_CI_01_ConfirmIdentityToSignInAndSignOut
	Given an apprentice login in to the service
	Then the apprentice is able to confirm the identitification details
	And the apprentice is able to logout from the service