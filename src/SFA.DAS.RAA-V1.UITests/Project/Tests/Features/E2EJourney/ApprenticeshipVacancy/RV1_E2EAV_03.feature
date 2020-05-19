Feature: RV1_E2EAV_03

@raa-v1
@v1_e2e
@regression
@apprenticeshipvacancy
Scenario Outline: RV1_E2EAV_03 - Create, Approve and Apply for a Apprenticeship Vacancy and make it Unsuccessful
	Given the Provider initiates Create Apprenticeship Vacancy in Recruit
	When the Provider chooses the employer '<location>','<NoOfPositions>'
	And the Provider chooses their '<anonymity>'
	And the Provider fills out details for an Offline Vacancy '<location>','<DisabilityConfident>','<ApplicationMethod>','<ApprenticeshipType>','<HoursPerWeek>','<VacancyDuration>'
	Then Provider is able to submit the vacancy for approval
	Then the Reviewer approves the vacancy
	When the Applicant apply for a Vacancy in FAA '<QualificationDetails>','<WorkExperience>','<TrainingCourse>'
	Then Provider can to make the application to be 'Unsuccessful'

	Examples:
		| location                      | anonymity | DisabilityConfident | ApplicationMethod | ApprenticeshipType | HoursPerWeek | VacancyDuration | NoOfPositions | QualificationDetails | WorkExperience | TrainingCourse |
		| Use the main employer address | No        | No                  | Online            | Framework          | 42           | 52              | 2             | No                   | No             | No             |