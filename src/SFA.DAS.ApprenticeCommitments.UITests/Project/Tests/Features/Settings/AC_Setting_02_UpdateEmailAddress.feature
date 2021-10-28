Feature: AC_Setting_01_UpdateEmailAddress

@apprenticecommitments
@regression
@deleteuser
Scenario: AC_Setting_01_UpdateEmailAddress
	Given an apprentice has a confirmed account
	Then an apprentice can change their email
