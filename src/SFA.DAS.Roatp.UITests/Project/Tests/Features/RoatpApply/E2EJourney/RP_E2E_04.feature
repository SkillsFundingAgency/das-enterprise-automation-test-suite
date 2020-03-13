Feature: RP_E2E_04

@rpe2e04
@roatp
@roatpapply
@roatpe2e
@regression
Scenario: RP_E2E_04_MainRoute-CompanyAndCharity
	Given the provider initates an application as main route company
	When the provider completes Your organisation section for company and charity
	And the provider completes Financial evidence section
	And the provider completes Criminal and Compliance section
	And the provider completes Protecting your apprentices section
	And the provider completes Readiness to engage section
	And the provider completes Planning apprenticeship training section
	And the provider completes Delivering apprenticeship training section for main route
	And the provider completes Evaluating apprenticeship training section
	Then the provider completes Finish section
	