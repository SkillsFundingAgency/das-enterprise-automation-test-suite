Feature: RV1_CLVS_01

@raa-v1
@regression
@apprenticeshipvacancy
Scenario: RV1_CVLS_01 - Close Vacancy which has NO Applications
	Given the apprenticeship vacancy is Live in Recruit with no application
	Then Provider is able to close this vacancy with no application