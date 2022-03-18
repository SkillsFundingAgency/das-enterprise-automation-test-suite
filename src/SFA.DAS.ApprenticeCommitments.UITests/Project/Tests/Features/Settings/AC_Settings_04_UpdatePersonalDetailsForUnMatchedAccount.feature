Feature: AC_Settings_04_UpdatePersonalDetailsBeforeConfirmingTheAccount

@apprenticecommitments
@regression
@accountsettingstest
@deleteuser
Scenario: AC_Settings_04_Update personal details before confirming the account
	Given an apprentice has created the account and about to validate personal details
	Then an apprentice change their personal details menu is available