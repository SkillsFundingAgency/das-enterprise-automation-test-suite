Feature: RV1_CVSD_01

@raa-v1
@regression
@apprenticeshipvacancy
Scenario: RV1_CVSD_01 - Change Vacancy dates which has NO Applications
	Given Provider views a vacancy which has 0 Applications
	Then Provider is able to change vacancy dates
