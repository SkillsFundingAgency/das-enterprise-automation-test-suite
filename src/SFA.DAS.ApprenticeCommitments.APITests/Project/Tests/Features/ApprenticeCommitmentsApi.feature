Feature: ApprenticeCommitmentsApi


@api
@apprenticecommitmentsapi
@outerapi
@regression
@apprenticecommitmentscreateaccount
Scenario: New apprenticeship email sent
	When an apprenticeship is posted
	Then a Accepted response is received
	And the apprentice details are updated in the login db

@api
@innerapi
	Scenario: Inner das-commitments-api heathcheck
	Then das-commitments-api /ping endpoint can be accessed
