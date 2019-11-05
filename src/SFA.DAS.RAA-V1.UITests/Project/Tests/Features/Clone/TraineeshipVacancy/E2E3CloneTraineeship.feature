Feature: E2E3CloneTraineeshipVacancy

A short summary of the feature

@raa-v1
@v1_e2e
@regression
Scenario Outline: E2E3 - Clone an existing Live Traineeship Vacancy, Approve and Apply
Given the Provider clones an existing traineeship
Then Provider is able to submit the vacancy for approval
Then the Reviewer approves the vacancy
When the Applicant apply for a Vacancy in FAA '<QualificationDetails>','<WorkExperience>','<TrainingCourse>'
Then the Provider is able to view the Applicant's application in Recruit

Examples:
| QualificationDetails | WorkExperience | TrainingCourse |
| No                   | Yes            | No             |