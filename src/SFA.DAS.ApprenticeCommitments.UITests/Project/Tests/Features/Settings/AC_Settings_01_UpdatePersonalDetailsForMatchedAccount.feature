Feature: AC_Settings_01_UpdatePersonalDetailsForMatchedAccount

@apprenticecommitments
@regression
@accountsettingstest
@deleteuser
Scenario: AC_Settings_01_UpdatePersonalDetails after confirming account
	Given an apprentice has a confirmed account
	Then an apprentice can change their personal details