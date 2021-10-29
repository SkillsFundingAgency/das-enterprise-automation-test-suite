Feature: AC_Setting_03_UpdatePassword

@apprenticecommitments
@regression
@deleteuser
Scenario: AC_Setting_03_UpdatePassword after confirming account
	Given an apprentice has a confirmed account
	Then an apprentice can change their password
