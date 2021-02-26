Feature: AC_RP_01_ResetPassword

@apprenticecommitments
@regression
@deleteuser
@deleteinvitation
Scenario: AC_RP_01_ResetPassword
	When an apprentice submits to reset password
	Then the apprentice can reset password using the invitation