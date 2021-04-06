Feature: RP_AD_GW_07
	
@resetApplicationToNew
@roatp
@roatpadmin
@newroatpadmin
@rpgateway
@rpadgw07
@regression
Scenario: RP_AD_GW_07A_SupportRoute_Removed_NEW_Application
	Given the admin lands on the Dashboard
	When the admin access the application from GatewayApplications
	Then the admin Removes the Application
	And the Gateway Applications Outcome tab is updated with REMOVED outcome for this Application
	And verify that the admin can send the application outcome as REMOVED to the applicant

	
@resetApplicationToNew
@roatp
@roatpadmin
@newroatpadmin
@rpgateway
@rpadgw07
@regression
Scenario: RP_AD_GW_07B_SupportRoute_Removed_InProgress_Application
	Given the admin lands on the Dashboard
	When the admin access the application from GatewayApplications
	And the gateway admin assess first subsection as PASS 
	Then the admin Removes the Application
	And the Gateway Applications Outcome tab is updated with REMOVED outcome for this Application


@resetApplicationToNew
@roatp
@roatpadmin
@newroatpadmin
@rpgateway
@rpadgw07
@regression
Scenario: RP_AD_GW_07C_SupportRoute_Removed_Clarification_Application
	Given the admin lands on the Dashboard
	When the admin access the application from GatewayApplications
	And the gateway admin assess all sections as PASS for Supporting Route Application
	And the gateway admin assess People in control checks as Clarification
	Then the gateway admin completes assessment by confirming Clarification is needed
	Then the admin Removes the Application
	And the Gateway Applications Outcome tab is updated with REMOVED outcome for this Application
 

@resetApplicationToNew
@roatp
@roatpadmin
@newroatpadmin
@rpgateway
@rpadgw07
@regression
Scenario: RP_AD_GW_07D_SupportRoute_Removed_OutcomeMade_Application
	Given the admin lands on the Dashboard
	When the admin access the application from GatewayApplications
	And the gateway admin assess all sections as PASS for Supporting Route Application
	Then the gateway admin completes assessment by confirming the Gateway outcome as PASS
	And the Gateway Applications Outcome tab is updated with PASS outcome for this Application
	And the admin access the application from Outcome tab
	Then the admin Removes the Application where outcome has been made
	And the Gateway Applications Outcome tab is updated with REMOVED outcome for this Application
 