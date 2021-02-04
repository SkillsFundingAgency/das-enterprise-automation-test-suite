Feature: ApprenticeCommitmentsApi


@apprenticecommitmentsapi
@regression
Scenario: Verify ApprenticeCommitmentsApi
	When an apprenticeship is posted
	Then a OK response is received