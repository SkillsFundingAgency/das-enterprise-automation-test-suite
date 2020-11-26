Feature: RP_AD_FHA_02

@resetFhaApplicationToNew
@roatp
@roatpadmin
@rpadfha02
@regression
Scenario: RP_AD_FHA_02
	Given the admin lands on the Dashboard	
	When the admin access the Financial Applications
	Then the Financial assessor completes assessment by confirming the Gateway outcome as Clarification
	And the Financial assessor completes the Clarification process by confirming the Gateway outcome as Inadequate
	And the Financial Applications Outcome tab is updated with Inadequate outcome for this Application