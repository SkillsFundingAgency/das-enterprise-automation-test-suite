@raa-v1
@regression
Feature: RV1_FAAV_04

@apprenticeshipvacancy
Scenario Outline: RV1_FAAV_04 Apply for an existing Apprenticeship Vacancy
	Given the applicant is on the Find an Apprenticeship Page
	When the applicant searches for the Vacancies '<JobTitle>','<Location>','<Distance>','<ApprenticeshipLevel>','<DisabilityConfident>'
	Then the applicant fills the application form '<QualificationDetails>','<WorkExperience>','<TrainingCourse>' when a qualified vacancy is found

	Examples:
		| JobTitle       | Location | Distance | ApprenticeshipLevel | DisabilityConfident | QualificationDetails | WorkExperience | TrainingCourse |
		| apprenticeship | CV1 2DY  | 30 miles | Higher              | Yes                 | Yes                  | Yes            | Yes            |