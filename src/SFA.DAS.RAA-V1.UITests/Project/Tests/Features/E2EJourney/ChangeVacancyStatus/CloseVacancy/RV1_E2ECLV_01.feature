Feature: RV1_E2ECLV_01

@raa-v1
@regression
@apprenticeshipvacancy
Scenario: RV1_E2ECLV_01 - Close Vacancy which has NO Applications
	Given the apprenticeship vacancy is Live in Recruit with no application
	Then Provider is able to close this vacancy with no application
	And the Vacancy is not found on FAA