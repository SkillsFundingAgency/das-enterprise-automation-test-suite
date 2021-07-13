Feature: RP_AD_FHA_01

@resetFhaApplicationToNew
@roatp
@newroatpadmin
@rpadfha01
@regression
Scenario: RP_AD_FHA_01
	Given the admin lands on the Dashboard
	When the admin access the Financial Applications
	Then the Financial assessor completes assessment by confirming the Financial outcome as outstanding
	And the Financial Applications Outcome tab is updated with Outstanding outcome for this Application