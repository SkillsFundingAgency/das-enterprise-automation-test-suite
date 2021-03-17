Feature: AC_CE_02_CanNotConfirmYourEmployer


@apprenticecommitments
@regression
@deleteuser
Scenario: AC_CE_02_CanNotConfirmYourEmployer
	Given an apprentice login in to the service
	Then the apprentice identity can be validated
	And the apprentice can not confirm the employer
