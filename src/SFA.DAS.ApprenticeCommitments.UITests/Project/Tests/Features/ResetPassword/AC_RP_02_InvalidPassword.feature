Feature: AC_RP_02_InvalidPassword

@apprenticecommitments
@regression
@deleteinvitation
Scenario: AC_RP_02_InvalidPassword
	When employer or provider submits the details to create an account
	Then an error is shown for invalid reset passwords