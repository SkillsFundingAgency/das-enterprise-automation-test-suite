Feature: RP_AD_OUTCOME_01

@roatp
@rpadoutcome01
@roatpadmin
@roatpoutcome
@newroatpadmin
@regression
Scenario: RP_AD_OUTCOME_01 Complete Outcome of a Company type Application via Main provider route
	Given the admin lands on the Dashboard
	Given the application is ready to be assessed
	When the oversight user approves gateway and moderation outcome
	Then verify the provider is added to the register with status of Onboarding