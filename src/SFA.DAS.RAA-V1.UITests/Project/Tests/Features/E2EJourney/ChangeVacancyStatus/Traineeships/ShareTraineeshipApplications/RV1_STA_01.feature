Feature: RV1_STA_01

@raa-v1
@regression
Scenario: RV1_STA_01 - Share Traineeship Vacancy Application which has Applications
	Given the traineeship vacancy is Live in Recruit with an application
	Then Provider is able to share vacancy application
