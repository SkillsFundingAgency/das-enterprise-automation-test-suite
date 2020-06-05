Feature: RV1_E2EARCHIVE_01

@raa-v1
@regression
@apprenticeshipvacancy
Scenario: RV1_E2EARCHIVE_01 - Archive vacancy which has Applications
	Given the apprenticeship vacancy is Live in Recruit with an application
	Then Provider is able to close this vacancy
	And Provider is able to archive vacancy