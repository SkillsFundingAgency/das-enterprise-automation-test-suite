Feature: ApprenticeCommitmentsApi


@apprenticecommitmentsapi
@regression
Scenario: Verify ApprenticeCommitmentsApi
	When an apprenticeship is posted
	Then a Accepted response is received
	And the apprentice details are updated in the login db


	Scenario: Commitment Api heathcheck
	Then I can access das commitments api
