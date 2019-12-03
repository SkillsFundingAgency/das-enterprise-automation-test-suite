Feature: RV1_CLVS_02

@raa-v1
@regression
@apprenticeshipvacancy
Scenario: RV1_CLVS_02 - Close Vacancy which has Applications
	Given the apprenticeship vacancy is Live in Recruit with an application
	Then Provider is able to close this vacancy