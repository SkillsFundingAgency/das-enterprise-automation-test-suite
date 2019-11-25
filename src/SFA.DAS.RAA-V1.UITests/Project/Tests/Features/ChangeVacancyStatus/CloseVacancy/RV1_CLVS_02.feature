Feature: RV1_CLVS_02

@raa-v1
@regression
@apprenticeshipvacancy
Scenario: RV1_CLVS_02 - Close Vacancy which has Applications
	Given Provider views a vacancy which has 1 Applications
	Then Provider is able to close this vacancy