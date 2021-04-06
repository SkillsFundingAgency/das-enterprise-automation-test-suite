Feature: AC_CP_01_ConfirmYourTrainingProvider

@apprenticecommitments
@regression
@deleteuser
Scenario: AC_CP_01_ConfirmYourTrainingProvider
	Given an apprentice has created and validated the account
	Then the apprentice is able to confirm the training provider
	And confirmed training provider already page is displayed for trying to confirm again