Feature: RP_AD_OUTCOME_01

@roatp
@rpadoutcome01
@roatpadmin
@roatpoutcome
@newroatpadmin
@regression
Scenario: RP_AD_OUTCOME_01A Complete Outcome of a Company type Application via Main provider route
	Given the admin lands on the Dashboard
	And the application with PASS outcome is ready to be assessed
	When the oversight user selects the overall application outcome as Successful
	Then Verify the application is transitioned to Oversight Outcome tab with SUCCESSFUL status
	Then verify the provider is added to the register with status of Onboarding



@roatp
@rpadoutcome01
@roatpadmin
@roatpoutcome
@newroatpadmin
@regression
Scenario: RP_AD_OUTCOME_01B Complete Outcome of a Company type Application via Main provider route unsuccessful Journey	
Given the admin lands on the Dashboard
And the application with PASS outcome is ready to be assessed	
When the oversight user overturns gateway and moderation outcome
And the oversight user selects the overall application outcome as Unsuccessful
Then Verify the application is transitioned to Oversight Outcome tab with UNSUCCESSFUL status
And verify the provider is not added to the register

@roatp
@rpadoutcome01
@roatpadmin
@roatpoutcome
@newroatpadmin
@regression
Scenario: RP_AD_OUTCOME_01BA Complete Outcome of a Company type Application via Main provider route Appeal Journey	
Given the Main provider is already on the RoATP register as Active
And the admin navigates to the Dashboard
And the application with PASS outcome is ready to be assessed
When the oversight user overturns gateway and moderation outcome
And the oversight user selects the overall application outcome as Unsuccessful
Then Verify the application is transitioned to Oversight Outcome tab with UNSUCCESSFUL status
And verify the provider is not added to the register
Then Oversight user is able to send the application to Appeal Status

@roatp
@rpadoutcome01
@roatpadmin
@roatpoutcome
@newroatpadmin
@regression
Scenario: RP_AD_OUTCOME_01C Complete Outcome of a Company type Application via Main provider route In Progress Journey	
Given the admin lands on the Dashboard
And the application with PASS outcome is ready to be assessed	
When the oversight user selects the overall application outcome as In Progress
Then Verify the application is transitioned to Oversight Outcome tab with IN PROGRESS status	
And verify the provider is not added to the register
Given the admin navigates to the Dashboard
And the application with IN PROGRESS outcome is ready to be assessed
When the oversight user selects the overall application outcome as Successful
Then Verify the application is transitioned to Oversight Outcome tab with SUCCESSFUL status
Then verify the provider is added to the register with status of Onboarding


@roatp
@rpadoutcome01
@roatpadmin
@roatpoutcome
@oldroatpadmin
@newroatpadmin
@regression
Scenario: RP_AD_OUTCOME_01D Complete Outcome of a Company type Application via Main provider route Successful already active Journey	
Given the Main provider is already on the RoATP register as Active
And the admin navigates to the Dashboard
And the application with PASS outcome is ready to be assessed
When the oversight user selects the overall application outcome as Successful already active
Then Verify the application is transitioned to Oversight Outcome tab with SUCCESSFUL status	
Then verify the provider is added to the register with Application determined date updated


@roatp
@rpadoutcome01
@roatpadmin
@roatpoutcome
@oldroatpadmin
@newroatpadmin
@regression
Scenario: RP_AD_OUTCOME_01E Complete Outcome of a Company type Application via Main provider route Successful fitness for funding Journey	
Given the Main provider is already on the RoATP register as Active But No Apprentice
And the admin navigates to the Dashboard
And the application with PASS outcome is ready to be assessed	
When the oversight user selects the overall application outcome as Successful fitness for funding
Then Verify the application is transitioned to Oversight Outcome tab with SUCCESSFUL status
Then verify the provider is added to the register with Application determined date updated
