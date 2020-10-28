Feature: RP_AD_MOD_01

@roatp
@rpadmod01
@roatpadmin
@roatpmoderator
@newroatpadmin
@regression
Scenario: RP_AD_MOD_01 Complete Moderation of a Company type Application via Main provider route
	Given the admin lands on the Dashboard
	When selects the Main provider route application from Moderation Tab
	Then the Moderator assesses all the sections of the Main Provider Route application as PASS
	Then the Moderator assesses the outcome as PASS
	Then the Outcome tab is updated as PASS