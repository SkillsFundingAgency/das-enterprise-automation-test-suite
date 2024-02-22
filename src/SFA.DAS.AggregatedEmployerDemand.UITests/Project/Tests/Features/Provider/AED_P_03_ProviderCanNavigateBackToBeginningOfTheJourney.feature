Feature: AED_P_03_ProviderCanNavigateBackToBeginningOfTheJourney

@aggregatedemployerdemand
@regression
@mailosaur
Scenario: AED_P_03_ProviderCanNavigateBackToBeginningOfTheJourney
	Given the employer has shared interest
	And the provider has provided their contact details
	Then the provider is able to navigate to beginning of the journey using the back links
