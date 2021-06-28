Feature: RP_FullEndToEnd_02_Employer

@roatp
@rpendtoend02apply
@roatpfulle2e
Scenario: RP_FullEndToEnd_02_EmployerRoute_Company_Complete_Apply_Gateway_Finance_Assessor_Moderation_Checks

	Given the Main provider is already on the RoATP register as Active
	Given the provider completes the Apply Journey as Employer Provider Route For Existing Provider
	When the GateWay user assess the application by confirming Gateway outcome as Pass
	And the Financial user assess the application by confirming Finance outcome as Outstanding
	And the Asssesssors assess the application and marks the application as Ready for Moderation
	Then the Moderation user assess the application and marks outcomes as Pass
	And the Oversight user assess the FAIL application as SUCCESSFUL fitness for funding and verifies the provider added to the register 
