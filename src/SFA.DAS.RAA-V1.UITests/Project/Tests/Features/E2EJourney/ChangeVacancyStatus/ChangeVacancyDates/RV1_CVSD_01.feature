Feature: RV1_CVSD_01

@raa-v1
@regression
@apprenticeshipvacancy
Scenario: RV1_CVSD_01 - Change Vacancy dates which has NO Applications
	Given the apprenticeship vacancy is Live in Recruit with no application
	Then Provider is able to change vacancy dates with no application
	And the Vacancy dates is changed in FAA