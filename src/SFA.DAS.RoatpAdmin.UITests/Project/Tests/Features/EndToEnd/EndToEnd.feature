Feature: RP_FullEndToEnd_01
@roatp
@rpendtoend01apply
@roatpendtoend
@roatpapply

    Scenario: RP_E2E_01_MainRoute_Company_Complete_Apply
	Given the provider initates an application as main route company
	When the provider completes Your organisation section
	And the provider completes Financial evidence section
	And the provider completes Criminal and Compliance section
	And the provider completes Protecting your apprentices section
	And the provider completes Readiness to engage section
	And the provider completes Planning apprenticeship training section
	And the provider completes Delivering apprenticeship training section for main route
	And the provider completes Evaluating apprenticeship training section
	Then the provider completes Finish section

@roatp
@rpadendtoend01
@roatpendtoend
@roatpadmin


	Scenario: RP_E2E_02_Complete_Gateway_Checks_Company_Type_Application_Main_Provider_Route
	Given the admin lands on the Dashboard
	When the admin access the MainRoute application from GatewayApplications
	And the gateway admin assess all sections as PASS for MainRoute Application
	Then the gateway admin completes assessment by confirming the Gateway outcome as PASS

@roatp
@rpadendtoend01
@roatpendtoend
@roatpadmin


	Scenario: RP_E2E_03_Financial_Helath_AssessmentChecks_Company_Type_Application_Main_Provider_Route
	Given the admin lands on the Dashboard
	When the admin access the FinancialApplications
	Then the Financial assessor completes assessment by confirming the Gateway outcome as Outstanding

@roatp
@rpadendtoend01
@roatpendtoend
@roatpassessoradmin

	Scenario: RP_E2E_04_Complete_Assessor_Checks_Company_Type_Application_Main_Provider_Route
	When the Assessor1 is on the RoATP assessor applications dashboard
	And selects the Main provider route application
	Then the Assessor assesses all the sections of the Main Provider Route application as PASS
	And marks the Application as Ready for moderation
	When the Assessor2 is on the RoATP assessor applications dashboard
	And selects the Main provider route application
	Then the Assessor assesses all the sections of the Main Provider Route application as PASS
	And marks the Application as Ready for moderation

@roatp
@rpadendtoend01
@roatpendtoend
@roatpadmin

	Scenario: RP_E2E_05_Complete_Moderation_Company_Type_Application_Main_Provider_Route
	Given the admin lands on the Dashboard
	When selects the Main provider route application from Moderation Tab
	Then the Moderator assesses all the sections of the application as PASS
