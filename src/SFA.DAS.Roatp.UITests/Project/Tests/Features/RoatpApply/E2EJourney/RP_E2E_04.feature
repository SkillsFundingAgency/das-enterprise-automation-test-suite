Feature: RP_E2E_04

@rpexistingprovider04
@roatpfulle2e
@roatp
@roatpfulle2eviaadmin
@regression
Scenario: RP_E2E_04_MainRoute-CompanyAndCharity_ExistingProvider
	Given the Provider is added to the register as Main provider
	And the provider naviagate to Apply 
	And the provider initates an application as Main Provider Route For Existing Provider 
	When the provider completes Your organisation section for company and charity
	And the provider completes Financial evidence section
	And the provider completes Criminal and Compliance section
	And the provider completes Protecting your apprentices section
	And the provider completes Readiness to engage section
	And the provider completes Planning apprenticeship training section for Main Provider Route For Existing Provider
	And the provider completes Delivering apprenticeship training section for main route
	And the provider completes Evaluating apprenticeship training section
	Then the provider completes Finish section
	