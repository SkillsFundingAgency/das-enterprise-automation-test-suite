Feature: RP_FullEndToEnd_02_Employer

@roatp
@rpendtoend02apply
@roatpfulle2e
Scenario: RP_FullEndToEnd_02_EmployerRoute_Company_Complete_Apply_Gateway_Finance_Assessor_Moderation_Checks

	Given the Main provider is already on the RoATP register as Active
	Given the provider completes the Apply Journey as Employer Provider Route For Existing Provider
	When the GateWay user assess the application by confirming Gateway outcome as Pass
	And the Financial user assess the application by confirming Finance outcome as inadequate
	And the Asssesssors assess the application and marks the application as Ready for Moderation
	Then the Moderation user assess the application and marks outcomes as Fail
	And the oversight user selects the overall application outcome as Successful fitness for funding
    Then Verify the application is transitioned to Oversight Outcome tab with SUCCESSFUL status
    Then verify the provider is added to the register with Application determined date updated
    And verify the Application successful page is displayed 
