Feature: RV1_CVS_01

@raa-v1
@regression
@apprenticeshipvacancy
Scenario Outline: RV1_CVS_01 - Close Vacancy which has NO Applications
	Given Provider views a vacancy which has NO Applications
	Then Provider is able to close this vacancy

Examples:
	| status               |
	| Close this vacancy   |
	#| Change vacancy dates |
	#| Increase wage        |