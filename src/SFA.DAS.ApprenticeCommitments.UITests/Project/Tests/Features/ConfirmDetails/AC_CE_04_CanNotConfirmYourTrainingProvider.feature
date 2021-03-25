Feature: AC_CE_04_CanNotConfirmYourTrainingProvider

@apprenticecommitments
@regression
@deleteuser
Scenario: AC_CE_04_CanNotConfirmYourTrainingProvider
	Given an apprentice login in to the service
	Then the apprentice identity can be validated
	And the apprentice can not confirm the training provider