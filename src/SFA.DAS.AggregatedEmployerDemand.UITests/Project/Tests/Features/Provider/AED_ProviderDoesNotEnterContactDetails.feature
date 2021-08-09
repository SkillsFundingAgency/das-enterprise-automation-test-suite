Feature: AED_ProviderDoesNotEnterContactDetails

@aggregatedemployerdemand
@regression
Scenario: AED_PDNECD_01_ProviderDoesNotEnterContactDetails
	Given the provider has not entered contact details
	Then the provider is presented with the validation error message before entering the correct details 'mailman@mailinator.com', '01902111222' and 'www.myinterestregister.com'