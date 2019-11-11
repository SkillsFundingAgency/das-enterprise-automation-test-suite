Feature: RV1_WDTV_01

@raa-v1
@regression
Scenario Outline: RV1_WDTV_01 - Withdraw Traineeship Vacancy
	Given the traineeship vacancy is Live in Recruit
		| location   | anonymity | Changeteam   | ChangeRole   | QualificationDetails   | WorkExperience   | TrainingCourse   |
		| <location> | Yes       | <Changeteam> | <ChangeRole> | <QualificationDetails> | <WorkExperience> | <TrainingCourse> |
	When the Applicant withdraw the application
	Then the vacancy should not be displayed in Recruit

	Examples:
		| location               | Changeteam    | ChangeRole       | QualificationDetails | WorkExperience | TrainingCourse |
		| Add different location | West Midlands | Vacancy reviewer | No                   | No             | No             |