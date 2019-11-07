Feature: RV1_E2EAV_01

@raa-v1
@v1_e2e
@regression
Scenario Outline: RV1_E2EAV_01 - Create, Approve and Apply for a Apprenticeship Vacancy
	Given the Provider initiates Create Apprenticeship Vacancy in Recruit
	When the Provider chooses the employer '<location>','<NoOfPositions>'
	And the Provider chooses their '<anonymity>'
	And the Provider fills out details for an Offline Vacancy '<location>','<DisabilityConfident>','<ApplicationMethod>','<ApprenticeshipType>','<HoursPerWeek>','<VacancyDuration>'
	Then Provider is able to submit the vacancy for approval
	When the Reviewer initiates reviewing the Vacancy in Manage
	Then the Reviewer is able to approve the Vacancy '<Changeteam>','<ChangeRole>'
	When the Applicant apply for a Vacancy in FAA '<QualificationDetails>','<WorkExperience>','<TrainingCourse>'
	Then the vacancy status should be Live in Recruit

	Examples:
		| location               | anonymity | DisabilityConfident | ApplicationMethod | ApprenticeshipType | HoursPerWeek | VacancyDuration | Changeteam    | ChangeRole       | NoOfPositions | QualificationDetails | WorkExperience | TrainingCourse |
		| Add different location | Yes       | Yes                 | Online            | Standard           | 42           | 52              | West Midlands | Vacancy reviewer | 3             | No                   | Yes            | No             |