Feature: RP_E2E_09

@rpe2e09
@roatp
@roatpapply
@roatpapplye2e
@regression
Scenario: RP_E2E_09_EmployerRoute_Charity_NewProvider
	Given the provider initates an application as employer route charity
	When the provider completes Your organisation section for charity
	And the provider completes Financial Evidence section for no ultimate parent company
	And the provider completes Criminal and Compliance section
	And the provider completes Protecting your apprentices section
	And the provider completes Readiness to engage section for charity
	And the provider completes Planning apprenticeship training section for charity Employer Provider Route
	And the provider completes Delivering apprenticeship training section for Employer Provider Route
	And the provider completes Evaluating apprenticeship training section
	Then the provider completes Finish section