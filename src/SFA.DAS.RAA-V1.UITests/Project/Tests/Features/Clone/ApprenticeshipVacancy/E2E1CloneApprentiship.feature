Feature: E2E1CloneApprentishipVacancy

A short summary of the feature

@V1_E2E
@regression
Scenario Outline: E2E1 - Clone an existing Live Apprenticeship Vacancy, Approve and Apply
Given the Provider clones an existing vacancy
Then Provider is able to submit the vacancy for approval
Then the Reviewer approves the vacancy
When the Applicant apply for a Vacancy in FAA '<QualificationDetails>','<WorkExperience>','<TrainingCourse>'
Then the Provider is able to view the Applicant's application in Recruit

Examples:
| QualificationDetails | WorkExperience | TrainingCourse |
| Yes                  | Yes            | Yes            |