Feature: ApprenticeshipVacancy

A short summary of the feature

@RAAV1_E2E
@regression
Scenario Outline: V1_E2E - Create, Approve and Apply for a Apprenticeship Vacancy
	Given the Provider initiates Create Apprenticeship Vacancy in Recruit
	#When the Provider chooses the employer '<location>','<NoOfPositions>'
	#And the Provider chooses their '<anonymity>'
	#And the Provider fills out details for an Offline Vacancy '<location>','<DisabilityConfident>','<ApplicationMethod>','<ApprenticeshipType>','<HoursPerWeek>','<VacancyDuration>'
	#Then Provider is able to submit the vacancy for approval
	When the Reviewer initiates reviewing the Vacancy in Manage
	Then the Reviewer is able to approve the Vacancy '<Changeteam>','<ChangeRole>'
	When the Applicant apply for a Vacancy in FAA '<QualificationDetails>','<WorkExperience>','<TrainingCourse>'
	Then the Provider is able to view the Applicant's application in Recruit

Examples:
| location                      | anonymity | DisabilityConfident | ApplicationMethod | ApprenticeshipType | HoursPerWeek | VacancyDuration | Changeteam    | ChangeRole       | NoOfPositions | QualificationDetails | WorkExperience | TrainingCourse |
| Use the main employer address | No        | No                  | Online            | Framework          | 42           | 52              | West Midlands | Vacancy reviewer | 2             | Yes                  | Yes            | Yes            |
| Add different location        | Yes       | Yes                 | Online            | Standard           | 42           | 52              | West Midlands | Vacancy reviewer | 3             | No                   | Yes            | No             |
| Set as a nationwide vacancy   | Yes       | Yes                 | Online            | Standard           | 42           | 52              | West Midlands | Vacancy reviewer | 3             | Yes                  | No             | No             |