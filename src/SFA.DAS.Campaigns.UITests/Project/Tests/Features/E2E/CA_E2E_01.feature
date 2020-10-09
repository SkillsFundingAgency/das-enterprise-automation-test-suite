Feature: CA_E2E_01

@campaignse2e
@campaigns
@employer
@regression
Scenario: CA_E2E_01_Employer favourites Apprenticeship and a Training Provider and removes them
	Given the employer searches for an apprenticeship
	When the employer shortlists favourite apprenticeship and provider
	Then the favourites are saved in gov uk account
	When the employer deletes the favourites
	Then there are no items in the favourites
	Then the basket is empty