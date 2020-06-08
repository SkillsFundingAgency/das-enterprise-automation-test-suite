Feature: RV1_E2EWDTV_01

@raa-v1
@regression
Scenario Outline: RV1_E2EWDTV_01 - Withdraw Traineeship Vacancy
	Given the traineeship vacancy is Live in Recruit
		| location   | anonymity | QualificationDetails   | WorkExperience   | TrainingCourse   |
		| <location> | Yes       | <QualificationDetails> | <WorkExperience> | <TrainingCourse> |
	When the Applicant withdraw the application
	Then the vacancy should not be displayed in Recruit

	Examples:
		| location                    | QualificationDetails | WorkExperience | TrainingCourse |
		| Set as a nationwide vacancy | No                   | No             | No             |