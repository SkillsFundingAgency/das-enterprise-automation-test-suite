Feature: TraineeshipVacancy

A short summary of the feature

@V1_E2E
Scenario Outline: V1_E2E - Create, Approve and Apply for a Traineeship Vacancy
Given the Provider initiates Create Apprenticeship Vacancy in Recruit
When the Provider chooses the employer '<location>','2'
And the Provider chooses their 'Yes'
And the Vacancy details are filled out for a Traineeship for a different '<location>'
Then Provider is able to submit the vacancy for approval
When the Reviewer initiates reviewing the Vacancy in Manage
Then the Reviewer is able to approve the Vacancy '<Changeteam>','<ChangeRole>'
When the Applicant initiates applying for a Vacancy in FAA
And Applicant searches for the Vacancy '<VacancyReference>'
And fills the application form '<QualificationDetails>','<WorkExperience>' ,'<TrainingCourse>'
Then the Provider is able to view the Applicant's application in Recruit

Examples:
| location                      | Changeteam    | ChangeRole       | Provider                                                             | QualificationDetails | WorkExperience | TrainingCourse |
| Use the main employer address | West Midlands | Vacancy reviewer | Department for Business, Innovation and Skills-Skills Funding Agency | No                   | No             | No             |
| Add different location        | West Midlands | Vacancy reviewer | Department for Business, Innovation and Skills-Skills Funding Agency | No                   | No             | No             |
| Set as a nationwide vacancy   | West Midlands | Vacancy reviewer | Department for Business, Innovation and Skills-Skills Funding Agency | No                   | No             | No             |

