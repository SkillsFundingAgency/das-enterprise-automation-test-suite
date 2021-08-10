Feature: AED_ProviderCanEditTheirLocationDetails

@aggregatedemployerdemand
@regression
Scenario: AED_PCETLD_01_ProviderCanEditTheirLocationDetails
	Given the employer has shared interest 'Coventry, West Midlands', 'Quinton Testing Ltd' and 'mailmanprovider@mailinator.com'
	And the provider has entered their contact details 'mailman@mailinator.com', '01902111222' and 'www.myinterestregister.com'
	When the provider selects the option to edit the location
	Then the provider is able to submit their location details