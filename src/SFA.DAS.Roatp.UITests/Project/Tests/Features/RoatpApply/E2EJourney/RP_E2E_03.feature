Feature: RP_E2E_03

@rpe2e03
@roatp
@roatpapply
@roatpapplye2e
@regression
Scenario: RP_E2E_03_SupportingRoute-Soletrader
	Given the provider initates an application as Supporting Provider Route
	When the provider completes Your organisation section for supporting route
	And the provider completes Financial Evidence section for supporting route
	And the provider completes Criminal and Compliance section
	And the provider completes Protecting your apprentices section for supporting route
	And the provider does not require to complete Readiness to engage section
	And the provider completes Planning apprenticeship training section for supporting route
	And the provider completes Delivering apprenticeship training section for supporting route
	And the provider completes Evaluating apprenticeship training section for supporting route
	Then the provider completes Finish section for supporting route