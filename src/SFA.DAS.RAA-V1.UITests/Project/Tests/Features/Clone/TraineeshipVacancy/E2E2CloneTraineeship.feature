Feature: E2E2CloneTraineeshipVacancy

A short summary of the feature

@V1_E2E
@regression
Scenario Outline: E2E2 - Clone an existing Live Traineeship Vacancy, Approve and Apply
Given the Provider clones an existing traineeship
Then Provider is able to submit the vacancy for approval
Then the Reviewer approves the vacancy
When the Applicant apply for a Vacancy in FAA '<QualificationDetails>','<WorkExperience>','<TrainingCourse>'
Then the Provider is able to view the Applicant's application in Recruit

Examples:
| QualificationDetails | WorkExperience | TrainingCourse |
| No                   | No             | No             |