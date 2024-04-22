Feature: AED_P_04_ProviderDoesNotEnterOrEnterInvalidContactDetails

@aggregatedemployerdemand
@regression
@mailosaur
Scenario: AED_P_04_ProviderDoesNotEnterOrEnterInvalidContactDetails
	Given the employer has shared interest
	Then An error is thrown if provider does not enter or enter invalid contact details
	Then the provider is able to submit the edited details