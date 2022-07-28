Feature: AC_Settings_01_UpdatePersonalDetailsAfterConfirmingTheAccount

@apprenticecommitments
@regression
@accountsettingstest
@deletecmaddatacreatedthroughapi
Scenario: AC_Settings_01_UpdatePersonalDetails after confirming the account
	Given an apprentice has a confirmed account
	Then an apprentice can change their personal details