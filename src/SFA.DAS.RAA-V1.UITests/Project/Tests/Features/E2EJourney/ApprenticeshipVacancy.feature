Feature: ApprenticeshipVacancy

A short summary of the feature

@V1_E2E
Scenario Outline: V1_E2E - Create, Approve and Apply for a Apprenticeship Vacancy
	Given the Provider initiates Create Apprenticeship Vacancy in Recruit
	When the Provider chooses the employer '<location>','<NoOfPositions>'
	And the Provider chooses their '<anonymity>'
	And the Provider fills out details for an Offline Vacancy '<location>','<Title>','<TypeOfVacancy>','<DisabilityConfident>','<ApplicationMethod>','<ApprenticeshipType>','<HoursPerWeek>','<VacancyDuration>'
	Then Provider is able to submit the vacancy for approval
	When the Reviewer initiates reviewing the Vacancy in 'Manage'
	Then the Reviewer is able to approve the Vacancy '<Changeteam>','<ChangeRole>','<Provider>','<VacancyReference>'
	When the Applicant initiates applying for a Vacancy in 'FAA'
	And Applicant searches for the Vacancy '<VacancyReference>'
	And fills the application form '<QualificationDetails>','<WorkExperience>' ,'<TrainingCourse>'
	Then the Provider is able to view the Applicant's application <VacancyReference> in 'Recruit'

Examples:
| location                      | anonymity | Title                  | TypeOfVacancy  | DisabilityConfident | ApplicationMethod | ApprenticeshipType | HoursPerWeek | VacancyDuration | Changeteam    | ChangeRole       | Provider                                                             | NoOfPositions | QualificationDetails | WorkExperience | TrainingCourse |
| Use the main employer address | No        | ManualTestingTitle     | Apprenticeship | No                  | Online            | Framework          | 42           | 52              | West Midlands | Vacancy reviewer | Department for Business, Innovation and Skills-Skills Funding Agency | 2             | Yes                  | Yes            | Yes            |
| Add different location        | Yes       | RegressionTestingTitle | Apprenticeship | Yes                 | Online            | Standard           | 42           | 52              | West Midlands | Vacancy reviewer | Department for Business, Innovation and Skills-Skills Funding Agency | 3             | No                   | Yes            | No             |
| Set as a nationwide vacancy   | Yes       | RegressionTestingTitle | Apprenticeship | Yes                 | Online            | Standard           | 42           | 52              | West Midlands | Vacancy reviewer | Department for Business, Innovation and Skills-Skills Funding Agency | 3             | Yes                  | No             | No             |