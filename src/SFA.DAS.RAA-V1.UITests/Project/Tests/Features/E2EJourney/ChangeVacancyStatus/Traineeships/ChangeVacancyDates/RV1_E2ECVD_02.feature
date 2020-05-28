Feature: RV1_E2ECVD_02

@raa-v1
@regression
Scenario: RV1_E2ECVD_02 - Change Vacancy dates which has Applications
	Given the traineeship vacancy is Live in Recruit with an application
	Then Provider is able to change vacancy dates
	And the Trainneship Vacancy dates is changed in FAA