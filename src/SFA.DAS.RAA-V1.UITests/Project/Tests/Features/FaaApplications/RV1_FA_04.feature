@raa-v1
@regression
Feature: RV1_FA_04
	
Scenario Outline: RV1_FA_04 Apply for an existing Apprenticeship Vacancy
Given the applicant is on the Find an Apprenticeship Page
When the applicant searches for the Vacancies '<JobTitle>','<Location>','<Distance>','<ApprenticeshipLevel>','<DisabilityConfident>'
Then  the applicant fills the application form '<QualificationDetails>','<WorkExperience>' ,'<TrainingCourse>'

Examples:
	| JobTitle       | Location | Distance | ApprenticeshipLevel | DisabilityConfident | QualificationDetails | WorkExperience | TrainingCourse |
	| apprenticeship | CV1 2DY  | 30 miles | Higher              | Yes                 | Yes                  | Yes            | Yes            |

