Feature: AED_ProviderCanShowInterestInEmployerDemand

@aed
@regression
Scenario: AED_PCSIIED_ProviderCanRegistertheirInterest
	Given the provider navigates to Find employers that need a training provider
	When the provider shows the which employers they are interested in
	And the provider is able to enter their details 'mailman@mailinator.com', '01902111222' and 'www.myinterestregister.com'
