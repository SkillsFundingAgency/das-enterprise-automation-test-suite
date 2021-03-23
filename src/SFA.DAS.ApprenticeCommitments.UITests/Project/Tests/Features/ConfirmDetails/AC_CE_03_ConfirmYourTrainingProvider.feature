Feature: AC_CE_03_ConfirmYourTrainingProvider

@apprenticecommitments
@regression
@deleteuser
Scenario: AC_CE_03_ConfirmYourTrainingProvider
	Given an apprentice login in to the service
	Then the apprentice identity can be validated
	And the apprentice can confirm the training provider