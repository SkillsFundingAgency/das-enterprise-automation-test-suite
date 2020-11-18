Feature: RP_AD_FHA_02

@resetFhaApplicationToNew
@roatp
@roatpadmin
@newroatpadmin
@rpadfha02
@regression
Scenario: RP_AD_FHA_02
	Given the admin lands on the Dashboard
	When the admin access the FinancialApplications
	Then the Financial assessor completes assessment by confirming the Gateway outcome as Inadequate
	Then the Financial Applications Outcome tab is updated as Inadequate