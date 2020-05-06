Feature: RP_E2E_05

@rpe2e05
@roatp
@roatpapply
@roatpe2e
@regression
Scenario: RP_E2E_05_EmployerRoute-Company -FHA Exempt
	Given the provider initates an application as employer route
	When the provider completes Your organisation section for FHA exemptions 
	And the provider verifies Financial Evidence section status as not required
	And the provider completes Criminal and Compliance section
	And the provider completes Protecting your apprentices section
	And the provider completes Readiness to engage section for charity
	And the provider completes Planning apprenticeship training section for charity
	And the provider completes Delivering apprenticeship training section for employer route
	And the provider completes Evaluating apprenticeship training section
	Then the provider completes Finish section
