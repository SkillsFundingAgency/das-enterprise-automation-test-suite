Feature: AED_ProviderCanShowInterestInEmployerDemand

@aed
@regression
Scenario: Add two numbers
	Given the provider navigates to Find employers that need a training provider
	When the provider shows the which employers they are interested in
	Then they are able to register their interest with the employer
