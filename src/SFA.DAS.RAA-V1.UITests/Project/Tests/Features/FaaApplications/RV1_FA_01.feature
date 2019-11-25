Feature: RV1_FA_01

A short summary of the feature

Scenario Outline: RV1_FA_01 Apply for an existing Apprenticeship Vacancy
Given the applicant is on the Find an Apprenticeship Page
When the applicant searches for the Vacancies '<JobTitle>','<Location>','<Distance>','<ApprenticeshipLevel>','<DisabilityConfident>'
Then  the applicant fills the application form '<QualificationDetails>','<WorkExperience>' ,'<TrainingCourse>'

Examples:
	| JobTitle       | Location | Distance | ApprenticeshipLevel | DisabilityConfident | QualificationDetails | WorkExperience | TrainingCourse |
	| apprenticeship | CV1 2DY  | 5 miles  | All levels          | Yes                 | No                   | No             | No             |
	| Test           | CV1 2WT  | 10 miles | Intermediate        | No                  | No                   | No             | No             |
	| apprenticeship | CV1 2DY  | 20 miles | Advanced            | Yes                 | No                   | No             | No             |
	| apprenticeship | CV1 2DY  | 30 miles | Higher              | Yes                 | Yes                  | Yes            | Yes            |
	| apprenticeship | CV1 2DY  | 40 miles | Degree              | Yes                 | Yes                  | Yes            | Yes            |