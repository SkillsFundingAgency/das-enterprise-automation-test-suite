Feature: RV1_AV_01

@raa-v1
@regression
@apprenticeshipvacancy
Scenario: RV1_AV_01 - Archive vacancy which has Applications
	Given Provider views a closed vacancy which has Applications
	Then Provider is able to archive vacancy


