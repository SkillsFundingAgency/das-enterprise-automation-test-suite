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
	And the gateway admin fails RegisterChecks
	Then the gateway admin completes assessment by confirming the Gateway outcome as Reject
	And the Gateway Applications Outcome tab is updated with REJECT outcome for this Application
	And Verifiy the application is not transitioned to PMO and Assessor
	And Verify the application is transitioned to Oversight for assessment