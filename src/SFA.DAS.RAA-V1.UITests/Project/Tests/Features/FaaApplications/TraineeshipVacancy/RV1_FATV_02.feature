@raa-v1
@regression
Feature: RV1_FATV_02

Scenario Outline: RV1_FATV_02 Apply for an existing Traineeship Vacancy
	Given the applicant is on the Find an Apprenticeship Page
	When the applicant searches for a traineeship Vacancies '<Location>','<Distance>','<DisabilityConfident>'
	Then the applicant fills the application form '<QualificationDetails>','<WorkExperience>','<TrainingCourse>' when a qualified vacancy is found

	Examples:
		| Location | Distance | DisabilityConfident | QualificationDetails | WorkExperience | TrainingCourse |
		| CV1 2WT  | 40 miles | Yes                 | Yes                  | Yes            | Yes            |