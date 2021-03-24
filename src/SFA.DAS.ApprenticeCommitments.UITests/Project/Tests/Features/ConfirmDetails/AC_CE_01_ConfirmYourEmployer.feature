Feature: AC_CE_01_ConfirmYourEmployer

@apprenticecommitments
@regression
@deleteuser
Scenario: AC_CE_01_ConfirmYourEmployer
	Given an apprentice login in to the service
	Then the apprentice identity can be validated
	And the apprentice can confirm the employer