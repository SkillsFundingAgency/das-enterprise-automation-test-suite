Feature: AC_CI_01_InvalidIdentityDetails

@apprenticecommitments
@regression
@deleteuser
Scenario: AC_CI_01_InvalidIdentityDetails
	Given an apprentice has created the account and about to validate personal details
	Then an error is shown for entering empty data
	And an error is shown for entering invalid identity data


@apprenticecommitments
@regression
@deleteuser
Scenario: AC_CI_02_NegativeMatchAndPositiveMatch
	Given an apprentice has created the account and about to validate personal details
	Then an error is shown for entering invalid identity data
	Then a positive match is shown after entering valid data