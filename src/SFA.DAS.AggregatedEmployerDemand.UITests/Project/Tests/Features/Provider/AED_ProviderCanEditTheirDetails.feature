Feature: AED_ProviderCanEditTheirContactDetails

@aggregatedemployerdemand
@regression
Scenario: AED_PCETCD_01_ProviderCanEditTheirContactDetails
	Given the provider has entered their contact details 'mailman@mailinator.com', '01902111222' and 'www.myinterestregister.com'
	When the provider selects the option to edit
	And the provider chooses to edit the contact details 'mailmanprovider@mailinator.com', '01902222111' and 'www.myproviderinterestregister.com'
	Then the provider is able to submit the edited details