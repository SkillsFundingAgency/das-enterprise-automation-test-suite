Feature: RV1_IVSW_01

@raa-v1
@regression
@apprenticeshipvacancy
Scenario: RV1_IVSW_01 - Increase Vacancy Wage dates which has NO Applications
	Given the apprenticeship vacancy is Live in Recruit with no application
	Then Provider is able to increase vacancy wage