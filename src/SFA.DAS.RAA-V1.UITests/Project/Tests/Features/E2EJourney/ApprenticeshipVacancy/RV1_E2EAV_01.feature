Feature: RV1_E2EAV_01

@raa-v1
@v1_e2e
@regression
@adddifferentlocation
@apprenticeshipvacancy
Scenario Outline: RV1_E2EAV_01 - Create, Approve and Apply for a Apprenticeship Vacancy and View Anonymous
	Given the Provider initiates Create Apprenticeship Vacancy in Recruit
	When the Provider chooses the employer '<location>','<NoOfPositions>'
	And the Provider chooses their '<anonymity>'
	And the Provider fills out details for an Offline Vacancy '<location>','<DisabilityConfident>','<ApplicationMethod>','<ApprenticeshipType>','<HoursPerWeek>','<VacancyDuration>'
	Then Provider is able to submit the vacancy for approval
	Then the Reviewer approves the vacancy
	When the Applicant apply for a Vacancy by browsing in FAA '<QualificationDetails>','<WorkExperience>','<TrainingCourse>'
	Then the vacancy can be viewed anonymously

	Examples:
		| location					  | anonymity | DisabilityConfident | ApplicationMethod | ApprenticeshipType | HoursPerWeek | VacancyDuration | NoOfPositions | QualificationDetails | WorkExperience | TrainingCourse |
		| Add different location      | Yes       | Yes                 | Online            | Standard           | 42           | 52              | 3             | No                   | Yes            | No             |