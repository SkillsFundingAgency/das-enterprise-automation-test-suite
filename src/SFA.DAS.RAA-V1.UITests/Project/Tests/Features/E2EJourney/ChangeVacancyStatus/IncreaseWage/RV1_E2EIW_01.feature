Feature: RV1_E2EIW_01

@raa-v1
@regression
@apprenticeshipvacancy
Scenario: RV1_E2EIW_01 - Increase Vacancy Wage dates which has NO Applications
	Given the apprenticeship vacancy is Live in Recruit with no application
	Then Provider is able to increase vacancy wage with no application
	And the Wage is changed in FAA