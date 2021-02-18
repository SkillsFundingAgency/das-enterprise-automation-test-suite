Feature: AC_CI_01_ConfirmIdentity


@apprenticecommitments
@regression
Scenario: AC_CI_01_ConfirmIdentity
	Given an apprentice login in to the service
	Then the apprentice identity can be validated
