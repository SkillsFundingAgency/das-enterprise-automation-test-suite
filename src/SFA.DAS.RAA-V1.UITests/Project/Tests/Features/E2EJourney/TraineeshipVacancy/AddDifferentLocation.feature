Feature: AddDifferentLocation

A short summary of the feature

@V1_E2E
@regression
Scenario Outline: E2E2 - Create, Approve and Apply for a Traineeship Vacancy
Given the Provider initiates Create Apprenticeship Vacancy in Recruit
When the Provider chooses the employer '<location>','2'
And the Provider chooses their 'Yes'
And the Vacancy details are filled out for a Traineeship for a different '<location>'
Then Provider is able to submit the vacancy for approval
When the Reviewer initiates reviewing the Vacancy in Manage
Then the Reviewer is able to approve the Vacancy '<Changeteam>','<ChangeRole>'
When the Applicant apply for a Vacancy in FAA '<QualificationDetails>','<WorkExperience>','<TrainingCourse>'
Then the Provider is able to view the Applicant's application in Recruit

Examples:
| location               | Changeteam    | ChangeRole       | QualificationDetails | WorkExperience | TrainingCourse |
| Add different location | West Midlands | Vacancy reviewer | No                   | No             | No             |


