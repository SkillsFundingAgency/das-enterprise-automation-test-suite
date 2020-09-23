Feature: CA_E2E_03

@Ignore
@campaigns
@employer
@regression
Scenario: CA_E2E_03_Employer adds multiple favourites
	Given the employer searches for an apprenticeship
	When the employer favourites multiple apprenticeship
	Then the favourites count is 3
	When the employer favourites multiple provider
	Then the favourites count is 6
	When the employer favourites multiple provider
	Then the favourites count is 9
	When the employer deletes all favourites apprenticeships
	Then the basket is empty