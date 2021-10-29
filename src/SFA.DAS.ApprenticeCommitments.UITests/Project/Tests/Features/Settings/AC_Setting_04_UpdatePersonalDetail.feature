Feature: AC_Setting_04_UpdatePersonalDetail

@apprenticecommitments
@regression
@deleteuser
Scenario: AC_Setting_04_UpdatePersonalDetail before confirming account
	Given an apprentice has created the account and about to validate personal details
	Then an apprentice can not change their personal details
