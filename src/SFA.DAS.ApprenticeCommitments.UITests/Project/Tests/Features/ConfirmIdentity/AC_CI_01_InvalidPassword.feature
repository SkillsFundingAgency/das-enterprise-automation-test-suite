Feature: AC_CI_01_InvalidPassword

@apprenticecommitments
@regression
@deleteuser
Scenario: AC_CI_01_InvalidPassword
	When an apprenticeship is created via API request
	Then an error is shown for entering mismatched passwords