Feature: RP_AD_GW_04

@resetApplicationToNew
@roatp
@roatpadmin
@newroatpadmin
@rpgateway
@rpadgw04
@regression
Scenario: RP_AD_GW_04_MainRoute_Company_Fail
	Given the admin lands on the Dashboard
	When the admin access the application from GatewayApplications
	And the gateway admin fails PeopleInControlChecks
	Then the gateway admin completes assessment by confirming the Gateway outcome as FAIL
	And the Gateway Applications Outcome tab is updated with FAIL outcome for this Application
	And Verifiy the application is not transitioned to PMO and Assessor
	And verify that the admin can send the application outcome as UNSUCCESSFUL to the applicant
	And verify the Application unsuccessful page is displayed with External Fail comments for the applicant