Feature: ApprenticeCommitmentsApi


@apprenticecommitmentsapi
@regression
Scenario: Verify ApprenticeCommitmentsApi
	When an apprenticeship is posted
	Then a Accepted response is received