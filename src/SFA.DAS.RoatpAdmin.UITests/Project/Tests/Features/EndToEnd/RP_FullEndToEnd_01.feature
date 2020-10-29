Feature: RP_FullEndToEnd_01

@roatp
@rpendtoend01apply
@roatpe2e
@roatpapply
Scenario: RP_FullEndToEnd_01_MainRoute_Company_Complete_Apply_Gateway_Finance_Assessor_Moderation_Checks
	Given the provider completes the Apply Journey as Main route company
	When the GateWay user assess the application by confirming Gateway outcome as Pass
	And the Financial user assess the application by confirming Finance outcome as Outstanding
	And the Asssesssors assess the application and marks the application as Ready for Moderation
	Then the Moderation user assess the application and marks outcomes as Pass
#
#@ignore
#@roatp
#@rpendtoend01apply
#@roatpe2e
#@roatpapply
#    Scenario: RP_FullEndToEnd_01_MainRoute_Company_Complete_Apply
#	Given the provider initates an application as main route company
#	When the provider completes Your organisation section
#	And the provider completes Financial evidence section
#	And the provider completes Criminal and Compliance section
#	And the provider completes Protecting your apprentices section
#	And the provider completes Readiness to engage section
#	And the provider completes Planning apprenticeship training section
#	And the provider completes Delivering apprenticeship training section for main route
#	And the provider completes Evaluating apprenticeship training section
#	Then the provider completes Finish section
#
#
#@ignore
#@roatp
#@rpadendtoend01
#@roatpendtoend
#@roatpadmin
#	Scenario: RP_E2E_02_Complete_Gateway_Checks_Company_Type_Application_Main_Provider_Route
#	Given the admin lands on the Dashboard
#	When the admin access the application from GatewayApplications
#	And the gateway admin assess all sections as PASS for MainRoute Application
#	Then the gateway admin completes assessment by confirming the Gateway outcome as PASS
#
#@roatp
#@rpadendtoend01
#@roatpendtoend
#@roatpadmin
#	Scenario: RP_E2E_03_Financial_Heath_AssessmentChecks_Company_Type_Application_Main_Provider_Route
#	Given the admin lands on the Dashboard
#	When the admin access the FinancialApplications
#	Then the Financial assessor completes assessment by confirming the Gateway outcome as Outstanding
#
#@ignore
#@roatp
#@rpadendtoend01
#@roatpendtoend
#@roatpassessoradmin
#	Scenario: RP_E2E_04_Complete_Assessor_Checks_Company_Type_Application_Main_Provider_Route
#	When the Assessor1 is on the RoATP assessor applications dashboard
#	And selects the Main Provider Route application
#	Then the Assessor assesses all the sections of the application as PASS
#	And marks the Application as Ready for moderation
#	When the Assessor2 is on the RoATP assessor applications dashboard
#	And the Assessor2 selects the same application
#	Then the Assessor assesses all the sections of the application as PASS
#	And marks the Application as Ready for moderation
#
#
#@ignore
#@roatp
#@rpadendtoend01
#@roatpendtoend
#@roatpadmin
#	Scenario: RP_E2E_05_Complete_Moderation_Company_Type_Application_Main_Provider_Route
#	Given the admin lands on the Dashboard
#	When selects the Main Provider Route application from Moderation Tab
#	Then the Moderator assesses all the sections of the application as PASS
