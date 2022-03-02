Feature: AED_P_01_ProviderShowInterestAndSubmitContactDetails

@aggregatedemployerdemand
@regression
Scenario: AED_P_01_provider show interest In employer demand and submit contact details
	Given the employer has shared interest
	And the provider has provided their contact details
	Then the provider can edit their contact details
