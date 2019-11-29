Feature: RV1_E2EAV_02

@raa-v1
@v1_e2e
@regression
@apprenticeshipvacancy
Scenario Outline: RV1_E2EAV_02 - Create, Approve and Apply for a Apprenticeship Vacancy
	Given the Provider initiates Create Apprenticeship Vacancy in Recruit
	When the Provider chooses the employer '<location>','<NoOfPositions>'
	And the Provider chooses their '<anonymity>'
	And the Provider fills out details for an Offline Vacancy '<location>','<DisabilityConfident>','<ApplicationMethod>','<ApprenticeshipType>','<HoursPerWeek>','<VacancyDuration>'
	Then Provider is able to submit the vacancy for approval
	Then the Reviewer approves the vacancy
	When the Applicant apply for a Vacancy in FAA '<QualificationDetails>','<WorkExperience>','<TrainingCourse>'
	Then the vacancy status should be Live in Recruit

	Examples:
		| location                    | anonymity | DisabilityConfident | ApplicationMethod | ApprenticeshipType | HoursPerWeek | VacancyDuration | NoOfPositions | QualificationDetails | WorkExperience | TrainingCourse |
		| Set as a nationwide vacancy | Yes       | Yes                 | Online            | Standard           | 42           | 52              | 3             | Yes                  | No             | No             |