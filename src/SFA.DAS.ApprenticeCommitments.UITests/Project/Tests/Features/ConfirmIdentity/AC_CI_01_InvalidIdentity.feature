Feature: AC_CI_01_InvalidIdentity

@apprenticecommitments
@regression
@deleteuser
Scenario: AC_CI_01_InvalidIdentity
	Given an apprentice has created the account and about to validate personal details
	Then an error is shown for entering invalid data