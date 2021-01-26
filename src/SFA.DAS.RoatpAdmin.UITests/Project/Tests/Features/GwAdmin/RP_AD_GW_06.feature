Feature: RP_AD_GW_06
	
@resetApplicationToNew
@roatp
@roatpadmin
@newroatpadmin
@rpgateway
@rpadgw06
@regression
Scenario: RP_AD_GW_06A_SupportRoute_Withdraw_NEW_Application
	Given the admin lands on the Dashboard
	When the admin access the application from GatewayApplications
	Then the admin Withdraws the Application
	And the Gateway Applications Outcome tab is updated with WITHDRAWN outcome for this Application

	
@resetApplicationToNew
@roatp
@roatpadmin
@newroatpadmin
@rpgateway
@rpadgw06
@regression
Scenario: RP_AD_GW_06B_SupportRoute_Withdraw_InProgress_Application
	Given the admin lands on the Dashboard
	When the admin access the application from GatewayApplications
	And the gateway admin assess first subsection as PASS 
	Then the admin Withdraws the Application
	And the Gateway Applications Outcome tab is updated with WITHDRAWN outcome for this Application


@resetApplicationToNew
@roatp
@roatpadmin
@newroatpadmin
@rpgateway
@rpadgw06
@regression
Scenario: RP_AD_GW_06C_SupportRoute_Withdraw_Clarification_Application
	Given the admin lands on the Dashboard
	When the admin access the application from GatewayApplications
	And the gateway admin assess all sections as PASS for Supporting Route Application
	And the gateway admin assess People in control checks as Clarification
	Then the gateway admin completes assessment by confirming Clarification is needed
	Then the admin Withdraws the Application
	And the Gateway Applications Outcome tab is updated with WITHDRAWN outcome for this Application
 

@resetApplicationToNew
@roatp
@roatpadmin
@newroatpadmin
@rpgateway
@rpadgw06
@regression
Scenario: RP_AD_GW_06D_SupportRoute_Withdraw_OutcomeMade_Application
	Given the admin lands on the Dashboard
	When the admin access the application from GatewayApplications
	And the gateway admin assess all sections as PASS for Supporting Route Application
	Then the gateway admin completes assessment by confirming the Gateway outcome as PASS
	And the Gateway Applications Outcome tab is updated with PASS outcome for this Application
	And the admin access the application from Outcome tab
	Then the admin Withdraws the Application where outcome has been made
	And the Gateway Applications Outcome tab is updated with WITHDRAWN outcome for this Application
 