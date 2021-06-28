Feature: RP_AD_GW_01

@resetApplicationToNew
@roatp
@roatpadmin
@newroatpadmin
@rpgateway
@rpadgw01
@regression
Scenario: RP_AD_GW_01_MainRoute_Company
	Given the admin lands on the Dashboard
	When the admin access the application from GatewayApplications
	And the gateway admin assess all sections as PASS for MainRoute Application
	Then the gateway admin completes assessment by confirming the Gateway outcome as PASS
	And the Gateway Applications Outcome tab is updated with PASS outcome for this Application