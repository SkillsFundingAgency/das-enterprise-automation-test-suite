Feature: RP_E2E_01


@rpe2e01
@roatp
@regression
Scenario: RP_E2E_01_MainRoute-Company
	Given the provider initates an application as main route company
	When the provider completes Your organisation section
	And the provider completes Criminal and Compliance section
	And the provider completes Protecting your apprentices section
	And the provider completes Readiness to engage section
	And the provider completes Planning apprenticeship training section
	And the provider completes Delivering apprenticeship training section
	And the provider completes Evaluating apprenticeship training section
	Then the provider completes Finish section

