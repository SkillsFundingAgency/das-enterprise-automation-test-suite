Feature: AC_CI_03_NegativeMatchAndPositiveMatch

@apprenticecommitments
@regression
@deleteuser
Scenario: AC_CI_03_NegativeMatchAndPositiveMatch
	Given an apprentice has created the account and about to validate personal details
	Then a Negative match Home page is shown for entering invalid identity data
	Then a Positive match Home page is shown after entering valid data