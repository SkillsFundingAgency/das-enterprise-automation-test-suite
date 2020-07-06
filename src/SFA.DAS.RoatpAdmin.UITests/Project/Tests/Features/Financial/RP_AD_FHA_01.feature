Feature: RP_AD_FHA_01

@resetFhaApplicationToNew
@roatp
@roatpadmin
@newroatpadmin
@rpadfha01
@regression
Scenario: RP_AD_FHA_01
	Given the admin lands on the Dashboard
	When the admin access the FinancialApplications
	Then the Financial assessor completes assessment by confirming the Gateway outcome as Outstanding