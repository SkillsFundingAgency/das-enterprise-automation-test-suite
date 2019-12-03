Feature: RV1_IVSW_01

@raa-v1
@regression
@apprenticeshipvacancy
Scenario: RV1_IVSW_01 - Increase Vacancy Wage dates which has NO Applications
	Given Provider views a vacancy which has 0 Applications
	Then Provider is able to increase vacancy wage