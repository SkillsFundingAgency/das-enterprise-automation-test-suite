Feature: AED_ProviderCanShowInterestInEmployerDemand

@aggregatedemployerdemand
@regression
Scenario: AED_PCSIIED_ProviderCanRegistertheirInterest
	Given the employer has shared interest 'Coventry, West Midlands', 'Quinton Testing Ltd' and 'mailmanprovider@mailinator.com'
	And the provider navigates to Find employers that need a training provider
	When the provider shows the which employers they are interested in
	And the provider is able to enter their details 'mailman@mailinator.com', '01902111222' and 'www.myinterestregister.com'