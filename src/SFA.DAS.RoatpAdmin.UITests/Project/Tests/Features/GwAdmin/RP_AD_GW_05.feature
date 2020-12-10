Feature: RP_AD_GW_05

@resetApplicationToNew
@roatp
@roatpadmin
@newroatpadmin
@rpgateway
@rpadgw05
@regression
Scenario: RP_AD_GW_05_EmployerRoute_Charity_Reject
	Given the admin lands on the Dashboard
	When the admin access the application from GatewayApplications
	And the gateway admin fails PeopleInControlChecks
	Then the gateway admin completes assessment by confirming the Gateway outcome as Reject