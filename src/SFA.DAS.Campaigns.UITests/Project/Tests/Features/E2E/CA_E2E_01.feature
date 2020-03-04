Feature: CA_E2E_01

@campaigns
@employer
@regression
Scenario: Employer Favourites Apprenticeship And A Training Provider
	Given the employer searches for an apprenticeship
	When the employer shortlists favourite apprenticeship and provider
	Then the favourites are saved in gov uk account
	#When the employer deletes the favourites
	#Then there are no items in the favourites