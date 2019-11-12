Feature: RV1_CLVS_01

@raa-v1
@regression
@apprenticeshipvacancy
Scenario: RV1_CVS_01 - Close Vacancy which has NO Applications
	Given Provider views a vacancy which has 0 Applications
	Then Provider is able to close this vacancy
