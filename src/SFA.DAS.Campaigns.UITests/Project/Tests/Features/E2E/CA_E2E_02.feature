Feature: CA_E2E_02

@campaignse2e
@campaigns
@employer
@regression
Scenario: CA_E2E_02_Employer adds and deletes favourites
	Given the employer searches for an apprenticeship
	When the employer favourites an apprenticeship
	And the employer favourites a provider
	Then the employer can delete the favourites
	Then the basket is empty
	