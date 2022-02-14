Feature: AC_Settings_03_UpdatePasswordForMatchedAccount

@apprenticecommitments
@regression
@accountsettingstest
@deleteuser
Scenario: AC_Settings_03_UpdatePassword after confirming account
	Given an apprentice has a confirmed account
	Then an apprentice can change their password