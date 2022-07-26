Feature: AC_Settings_03_UpdatePasswordAfterConfirmingTheAccount

@apprenticecommitments
@regression
@accountsettingstest
@deletecmaddatacreatedthroughapi
Scenario: AC_Settings_03_UpdatePassword after confirming the account
	Given an apprentice has a confirmed account
	Then an apprentice can change their password