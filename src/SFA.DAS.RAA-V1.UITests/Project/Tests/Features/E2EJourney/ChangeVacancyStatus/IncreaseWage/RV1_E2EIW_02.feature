Feature: RV1_E2EIW_02

@raa-v1
@regression
@apprenticeshipvacancy
Scenario: RV1_E2EIW_02 - Increase Vacancy Wage which has Applications
	Given the apprenticeship vacancy is Live in Recruit with an application
	Then Provider is able to increase vacancy wage
	And the Wage is changed in FAA