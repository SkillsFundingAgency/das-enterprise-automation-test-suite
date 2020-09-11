Feature: RP_AD_GW_03
	
@resetApplicationToNew
@roatp
@roatpadmin
@newroatpadmin
@rpgateway
@rpadgw03
@regression
Scenario: RP_AD_GW_02_EmployerRoute_Charity
	Given the admin lands on the Dashboard
	When the admin access the SupportingRoute application from GatewayApplications
	And the gateway admin assess all sections as PASS for Supporting Route Application
	Then the gateway admin completes assessment by confirming the Gateway outcome as PASS