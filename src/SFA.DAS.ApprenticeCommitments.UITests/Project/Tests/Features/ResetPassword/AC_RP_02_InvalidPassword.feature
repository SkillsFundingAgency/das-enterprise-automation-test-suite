Feature: AC_RP_02_InvalidPassword

@apprenticecommitments
@regression
@deleteinvitation
@deleteuser
Scenario: AC_RP_02_InvalidPassword
	When an apprentice submits to reset password
	Then an error is shown for invalid reset passwords