Feature: RP_E2E_08

@rpe2e08
@roatp
@roatpapply
@roatpapplye2e
@regression
Scenario: RP_E2E_08_MainRoute_Company_NewProvider
	Given the provider initates an application as main route company
	When the provider completes Your organisation section
	And the provider completes Financial evidence section
	And the provider completes Criminal and Compliance section
	And the provider completes Protecting your apprentices section
	And the provider completes Readiness to engage section
	And the provider completes Planning apprenticeship training section for Main Provider Route
	And the provider completes Delivering apprenticeship training section for main route
	And the provider completes Evaluating apprenticeship training section
	Then the provider completes Finish section
