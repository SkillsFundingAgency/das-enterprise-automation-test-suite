Feature: AC_Settings_04_UpdatePersonalDetailForUnMatchedAccount

@apprenticecommitments
@regression
@accountsettingstest
@deleteuser
Scenario: AC_Settings_04_UpdatePersonalDetail before confirming account
	Given an apprentice has created the account and about to validate personal details
	Then an apprentice change their personal details menu is available
