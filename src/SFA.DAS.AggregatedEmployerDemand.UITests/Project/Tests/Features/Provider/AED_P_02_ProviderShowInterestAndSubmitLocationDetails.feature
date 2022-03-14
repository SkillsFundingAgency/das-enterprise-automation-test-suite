Feature: AED_P_02_ProviderShowInterestAndSubmitLocationDetails

@aggregatedemployerdemand
@regression
Scenario: AED_P_02_provider show interest In employer demand and submit location details
	Given the employer has shared interest
	And the provider has provided their contact details
	Then the provider is able to submit their location details