Feature: AED_ProviderEntersInvalidEmailFormat

@aggregatedemployerdemand
@regression
Scenario: AED_PEIEAPF_01_ProviderEntersInvalidEmailAndPhoneFormat
	Given the employer has shared interest 'Coventry, West Midlands', 'Quinton Testing Ltd' and 'mailmanprovider@mailinator.com'
	And the provider has entered their email contact details incorrectly 'mailman@mailinator@com', '01902111222XXX08KER32' and 'www.myinterestregister.com'
	When the provider is presented with the validation error message before entering the correct details 'mailman@mailinator.com', '01902111222' and 'www.myinterestregister.com'
	Then the provider is able to submit the edited details