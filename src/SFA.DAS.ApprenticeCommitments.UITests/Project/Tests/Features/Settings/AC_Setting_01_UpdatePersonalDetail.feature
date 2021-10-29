Feature: AC_Setting_01_UpdatePersonalDetail

@apprenticecommitments
@regression
@deleteuser
Scenario: AC_Setting_01_UpdatePersonalDetail after confirming account
	Given an apprentice has a confirmed account
	Then an apprentice can change their personal details
