Feature: RP_FullEndToEnd_02_Employer

@roatp
@rpendtoend02apply
@roatpfulle2eviaadmin
@roatpfulle2e
Scenario: RP_FullEndToEnd_02_EmployerRoute_Charity_Complete_Apply_Gateway_Finance_Assessor_Moderation_Checks_SuccessfulFitnessForFunding

	Given the Main provider is already on the RoATP register as Active
	And the provider naviagate to Apply 
	Given the provider completes the Apply Journey as Employer Provider Route For Existing Provider
	When the GateWay user assess the application by confirming Gateway outcome as Pass
	And the Financial user assess the application by confirming Finance outcome as inadequate
	And the Asssesssors assess the application and marks the application as Ready for Moderation
	Then the Moderation user assess the application and marks outcomes as Fail
	And the FAIL status overall application is marked as UnSuccessful
    Then Verify the application is transitioned to Oversight Outcome tab with UNSUCCESSFUL status
    And verify the Application unsuccessful page is displayed 
