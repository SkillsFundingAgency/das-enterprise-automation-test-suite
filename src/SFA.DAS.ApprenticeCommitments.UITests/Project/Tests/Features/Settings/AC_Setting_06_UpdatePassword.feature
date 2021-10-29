Feature: AC_Setting_06_UpdatePassword

@apprenticecommitments
@regression
@accountsettingstest
@deleteuser
Scenario: AC_Setting_06_UpdatePassword before confirming account
	Given an apprentice has created the account and about to validate personal details
	Then an apprentice can change their password before confirming account
