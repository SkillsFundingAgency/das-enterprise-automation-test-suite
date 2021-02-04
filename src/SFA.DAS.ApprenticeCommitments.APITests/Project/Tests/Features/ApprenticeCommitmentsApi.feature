Feature: ApprenticeCommitmentsApi


@apprenticecommitmentsapi
@regression
Scenario: Verify ApprenticeCommitmentsApi
	When an apprenticeship is posted
	Then an invitation is sent successfully