Feature: RV1_CVS_01

@raa-v1
@regression
Scenario Outline: RV1_CVS_01 - Change Vacancy status which has NO Applications
	Given Provider views a vacancy which has NO Applications
	Then Provider is able to change the '<status>' of the vacancy

Examples:
	| status               |
	| Close this vacancy   |
	| Change vacancy dates |
	| Increase wage        |