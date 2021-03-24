Feature: AC_CE_01_ConfirmYourEmployer

@apprenticecommitments
@regression
@deleteuser
Scenario: AC_CE_01_ConfirmYourEmployer
	Given an apprentice has created an validated the account
	Then the apprentice is able to confirm the employer
	And confirmed employer already page is displayed for trying to confirm again 