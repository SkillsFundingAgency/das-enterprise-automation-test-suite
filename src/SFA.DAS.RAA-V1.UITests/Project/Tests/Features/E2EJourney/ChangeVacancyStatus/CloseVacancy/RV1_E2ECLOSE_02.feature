Feature: RV1_E2ECLOSE_02

@raa-v1
@regression
@apprenticeshipvacancy
Scenario: RV1_E2ECLOSE_02 - Close Vacancy which has Applications
	Given the apprenticeship vacancy is Live in Recruit with an application
	Then Provider is able to close this vacancy