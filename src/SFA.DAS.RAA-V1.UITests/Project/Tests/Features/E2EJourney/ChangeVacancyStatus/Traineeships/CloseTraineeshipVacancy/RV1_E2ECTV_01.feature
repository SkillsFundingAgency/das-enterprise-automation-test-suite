Feature: RV1_E2ECTV_01

@raa-v1
@regression
Scenario: RV1_E2ECTV_01 - Close Traineeship Vacancy Which has no Applications
	Given the traineeship vacancy is Live in Recruit with no application
	Then Provider is able to close this vacancy with no application
	Then the Traineeship Vacancy is not found on FAA