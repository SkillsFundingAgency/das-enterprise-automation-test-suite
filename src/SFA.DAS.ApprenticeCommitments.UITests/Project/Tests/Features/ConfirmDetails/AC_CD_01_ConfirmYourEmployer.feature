Feature: AC_CD_01_ConfirmYourEmployer

@apprenticecommitments
@regression
@deleteuser
Scenario: AC_CD_01_ConfirmYourEmployer
	Given an apprentice has created and validated the account
	Then the apprentice is able to confirm the Employer
	And confirmed employer already page is displayed for trying to confirm again