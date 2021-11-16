Feature: AC_Settings_05_UpdateEmailAddressForUnMatchedAccount

@apprenticecommitments
@regression
@accountsettingstest
@deleteuser
Scenario: AC_Settings_05_UpdateEmailAddress before confirming account
	Given an apprentice has created the account and about to validate personal details
	Then an apprentice can change their email before confirming account
