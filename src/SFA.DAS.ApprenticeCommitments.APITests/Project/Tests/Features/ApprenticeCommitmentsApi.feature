Feature: ApprenticeCommitmentsApi


@api
@apprenticecommitmentsapi
@outerapi
@regression
Scenario: Verify ApprenticeCommitmentsApi
	When an apprenticeship is posted
	Then a Accepted response is received
	And the apprentice details are updated in the login db

@api
@innerapi
	Scenario: Commitment Api heathcheck
	Then I can access das commitments api
