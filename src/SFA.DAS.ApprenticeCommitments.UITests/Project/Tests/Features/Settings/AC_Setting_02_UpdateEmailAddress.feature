Feature: AC_Setting_02_UpdateEmailAddress

@apprenticecommitments
@regression
@accountsettingstest
@deleteuser
Scenario: AC_Setting_02_UpdateEmailAddress after confirming account
	Given an apprentice has a confirmed account
	Then an apprentice can change their email
