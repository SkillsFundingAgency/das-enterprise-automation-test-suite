Feature: AC_Settings_02_UpdateEmailAddressForMatchedAccount

@apprenticecommitments
@regression
@accountsettingstest
@deleteuser
Scenario: AC_Settings_02_UpdateEmailAddress after confirming account
	Given an apprentice has a confirmed account
	Then an apprentice can change their email
