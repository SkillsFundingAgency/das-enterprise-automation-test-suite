Feature: AED_ProviderCanNavigateBackToBeginningOfTheJourney

@aggregatedemployerdemand
@regression
Scenario: AED_PCNBTBOTJ_ProviderCanNavigateBackToBeginningOfTheJourney
	Given the provider has entered their contact details 'mailman@mailinator.com', '01902111222' and 'www.myinterestregister.com'
	Then the provider is able to navigate to beginning of the journey using the back links
