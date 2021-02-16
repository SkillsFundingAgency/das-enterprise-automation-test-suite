Feature: AC_CA_02

@apprenticecommitmentscreateaccount
@apprenticecommitments
@regression
Scenario: AC_CA_02_Invalid_Password_does_not_match
	When employer or provider submits the details to create an account
	Then an error is shown for invalid password does not match