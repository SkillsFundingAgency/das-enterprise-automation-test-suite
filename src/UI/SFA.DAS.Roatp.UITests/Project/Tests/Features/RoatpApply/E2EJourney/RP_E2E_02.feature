Feature: RP_E2E_02

@rpexistingprovider02
@roatpfulle2e
@roatp
@roatpfulle2eviaadmin
@regression
Scenario: RP_E2E_02_EmployerRoute-Charity_ExistingProvider
	Given the Provider is added to the register as Employer provider
	And the provider naviagate to Apply 
	And the provider initates an application as Employer Provider Route For Existing Provider 
	When the provider completes Your organisation section for charity
	And the provider completes Financial Evidence section for no ultimate parent company
	And the provider completes Criminal and Compliance section
	And the provider completes Protecting your apprentices section
	And the provider completes Readiness to engage section for charity
	And the provider completes Planning apprenticeship training section for charity Employer Provider Route For Existing Provider 
	And the provider completes Delivering apprenticeship training section for Employer Provider Route For Existing Provider 
	And the provider completes Evaluating apprenticeship training section
	Then the provider completes Finish section