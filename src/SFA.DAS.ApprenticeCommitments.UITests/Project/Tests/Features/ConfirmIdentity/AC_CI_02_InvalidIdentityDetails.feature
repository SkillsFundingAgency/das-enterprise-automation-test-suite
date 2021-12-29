Feature: AC_CI_02_InvalidIdentityDetails

@apprenticecommitments
@regression
@deleteuser
Scenario: AC_CI_02_InvalidIdentityDetails
	Given an apprentice has created the account and about to validate personal details
	Then an error is shown for entering empty data
	And a Negative match Home page is shown for entering invalid identity data