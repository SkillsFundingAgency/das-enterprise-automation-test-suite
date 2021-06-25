Feature: RP_FullEndToEnd_01

@roatp
@rpendtoend01apply
@roatpfulle2e
Scenario: RP_FullEndToEnd_01_MainRoute_Company_Complete_Apply_Gateway_Finance_Assessor_Moderation_Checks
	Given the provider completes the Apply Journey as Main Provider Route
	When the GateWay user assess the application by confirming Gateway outcome as Pass
	And the Financial user assess the application by confirming Finance outcome as Outstanding
	And the Asssesssors assess the application and marks the application as Ready for Moderation
	Then the Moderation user assess the application and marks outcomes as Pass
	And the Oversight user assess the PASS application as Successful and verifies the provider added to the register 
