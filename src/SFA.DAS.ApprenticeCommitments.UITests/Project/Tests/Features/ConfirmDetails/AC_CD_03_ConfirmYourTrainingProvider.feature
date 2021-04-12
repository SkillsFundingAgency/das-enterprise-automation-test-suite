Feature: AC_CD_03_ConfirmYourTrainingProvider

@apprenticecommitments
@regression
@deleteuser
Scenario: AC_CD_03_ConfirmYourTrainingProvider
	Given an apprentice has created and validated the account
	Then the apprentice is able to confirm the Training Provider
	And confirmed training provider already page is displayed for trying to confirm again