Feature: RV1_SA_01

@raa-v1
@regression
@apprenticeshipvacancy
Scenario: RV1_SA_01 - Share Vacancy Application which has Applications
	Given Provider views a vacancy which has 1 Applications
	Then Provider is able to share vacancy application
