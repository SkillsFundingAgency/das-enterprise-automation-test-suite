Feature: RP_AD_OUTCOME_01

@roatp
@rpadoutcome01
@roatpadmin
@roatpoutcome
@newroatpadmin
@regression
Scenario: RP_AD_OUTCOME_01 Complete Outcome of a Company type Application via Main provider route
	Given the admin lands on the Dashboard
	And the application with PASS outcome is ready to be assessed
	When the oversight user approves gateway and moderation outcome
	Then Verify the application is transitioned to Oversight Outcome tab with SUCCESSFUL status
	Then verify the provider is added to the register with status of Onboarding



@roatp
@rpadoutcome01
@roatpadmin
@roatpoutcome
@newroatpadmin
@regression
Scenario: RP_AD_OUTCOME_01A Complete Outcome of a Company type Application via Main provider route unsuccessful Journey	
Given the admin lands on the Dashboard
And the application with PASS outcome is ready to be assessed	
When the oversight user overturns gateway and moderation outcome
And the oversight user selects the overall application outcome as Unsuccessful
Then Verify the application is transitioned to Oversight Outcome tab with UNSUCCESSFUL status	
And verify the provider is not added to the register