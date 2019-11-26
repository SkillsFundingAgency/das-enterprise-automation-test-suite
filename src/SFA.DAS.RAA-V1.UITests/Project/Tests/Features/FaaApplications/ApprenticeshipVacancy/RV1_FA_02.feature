@raa-v1
@regression
Feature: RV1_FA_02

@apprenticeshipvacancy
Scenario Outline: RV1_FA_02 Apply for an existing Apprenticeship Vacancy
Given the applicant is on the Find an Apprenticeship Page
When the applicant searches for the Vacancies '<JobTitle>','<Location>','<Distance>','<ApprenticeshipLevel>','<DisabilityConfident>'
Then  the applicant fills the application form '<QualificationDetails>','<WorkExperience>' ,'<TrainingCourse>'

Examples:
	| JobTitle | Location | Distance | ApprenticeshipLevel | DisabilityConfident | QualificationDetails | WorkExperience | TrainingCourse |
	| Test     | CV1 2WT  | 10 miles | Intermediate        | No                  | No                   | No             | No             |
