Feature: RV1_E2ECAVD_02

@raa-v1
@regression
@apprenticeshipvacancy
Scenario: RV1_E2ECAVD_02 - Change Vacancy dates which has Applications
	Given the apprenticeship vacancy is Live in Recruit with an application
	Then Provider is able to change vacancy dates
	And the Vacancy dates is changed in FAA