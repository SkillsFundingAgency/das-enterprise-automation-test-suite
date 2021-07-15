Feature: RP_FullEndToEnd_01_Main

@roatp
@rpendtoend01apply
@roatpfulle2eviaapply
@roatpfulle2e
Scenario: RP_FullEndToEnd_01_MainRoute_Company_Complete_Apply_Gateway_Finance_Assessor_Moderation_Checks_Successful
	Given the provider completes the Apply Journey as Main Provider Route
	When the GateWay user assess the application by confirming Gateway outcome as Pass
	And the Financial user assess the application by confirming Finance outcome as outstanding
	And the Asssesssors assess the application and marks the application as Ready for Moderation
	Then the Moderation user assess the application and marks outcomes as Pass
	And the PASS status overall application is marked as Successful
	Then Verify the application is transitioned to Oversight Outcome tab with SUCCESSFUL status
	And verify the provider is added to the register with status of Onboarding
	And verify the Application successful page is displayed 
