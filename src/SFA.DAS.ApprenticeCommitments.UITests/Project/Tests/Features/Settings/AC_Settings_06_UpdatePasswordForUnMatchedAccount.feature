Feature: AC_Settings_06_UpdatePasswordBeforeConfirmingTheAccount

@apprenticecommitments
@regression
@accountsettingstest
@deleteuser
Scenario: AC_Settings_06_Update password before confirming the account
	Given an apprentice has created the account and about to validate personal details
	Then an apprentice can change their password before confirming account