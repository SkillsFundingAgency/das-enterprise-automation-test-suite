Feature: AC_Settings_02_UpdateEmailAddressAfterConfirmingTheAccount

@apprenticecommitments
@regression
@accountsettingstest
@deletecmaddatacreatedthroughapi
@cmadupdatedemail
Scenario: AC_Settings_02_Update EmailAddress after confirming the account
	Given an apprentice has a confirmed account
	Then an apprentice can change their email