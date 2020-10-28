Feature: RP_AD_MOD_02
	
@roatp
@rpadmod02
@roatpadmin
@roatpmoderator
@newroatpadmin
@regression
Scenario: RP_AD_MOD_02 Complete Moderation of a Soletrader Application via Supporting provider route
	Given the admin lands on the Dashboard
	When selects the Supporting provider route application from Moderation Tab
	Then the Moderator assesses all the sections of the application as PASS
	Then the Moderator FAILS few sections
	Then the Moderator assesses the outcome as FAIL
	Then the Outcome tab is updated as FAIL