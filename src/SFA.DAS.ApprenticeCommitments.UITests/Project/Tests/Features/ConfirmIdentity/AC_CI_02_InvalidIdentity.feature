Feature: AC_CI_02_InvalidIdentity


@apprenticecommitments
@regression
@deleteinvitation
@deleteuser
Scenario: AC_CI_02_InvalidIdentity
	Given an apprentice login in to the service
	Then an error is shown for invalid data
