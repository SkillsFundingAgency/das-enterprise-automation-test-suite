Feature: RV1_E2EAV_04

@raa-v1
@v1_e2e
@regression
@apprenticeshipvacancy
Scenario Outline: RV1_E2EAV_04 - Create an Offline Apprenticeship Vacancy
	Given the Provider initiates Create Apprenticeship Vacancy in Recruit
	When the Provider chooses the employer '<location>','<NoOfPositions>'
	And the Provider chooses their '<anonymity>'
	And the Provider fills out details for an Offline Vacancy '<location>','<DisabilityConfident>','<ApplicationMethod>','<ApprenticeshipType>','<HoursPerWeek>','<VacancyDuration>'
	Then Provider is able to submit the vacancy for approval
	
	Examples:
		| location                      | anonymity | DisabilityConfident | ApplicationMethod | ApprenticeshipType | HoursPerWeek | VacancyDuration | Changeteam    | ChangeRole       | NoOfPositions | QualificationDetails | WorkExperience | TrainingCourse |
		| Use the main employer address | No        | No                  | Offline           | Framework          | 42           | 52              | West Midlands | Vacancy reviewer | 2             | Yes                  | Yes            | Yes            |