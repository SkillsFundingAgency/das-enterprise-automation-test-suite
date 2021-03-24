Feature: AC_CE_03_ConfirmYourTrainingProvider

@apprenticecommitments
@regression
@deleteuser
Scenario: AC_CE_03_ConfirmYourTrainingProvider
	Given an apprentice has created an validated the account
	Then the apprentice is able to confirm the training provider
	And confirmed training provider already page is displayed for trying to confirm again