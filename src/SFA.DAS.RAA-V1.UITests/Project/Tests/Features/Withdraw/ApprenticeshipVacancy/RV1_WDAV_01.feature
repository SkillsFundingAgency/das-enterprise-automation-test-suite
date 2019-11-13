Feature: RV1_WDAV_01

@raa-v1
@regression
Scenario Outline: RV1_WDAV_01 - Withdraw Apprenticeship Vacancy
	Given the apprenticeship vacancy is Live in Recruit
		| location   | anonymity   | DisabilityConfident   | ApplicationMethod   | ApprenticeshipType   | HoursPerWeek   | VacancyDuration   | Changeteam   | ChangeRole   | NoOfPositions   | QualificationDetails   | WorkExperience   | TrainingCourse   |
		| <location> | <anonymity> | <DisabilityConfident> | <ApplicationMethod> | <ApprenticeshipType> | <HoursPerWeek> | <VacancyDuration> | <Changeteam> | <ChangeRole> | <NoOfPositions> | <QualificationDetails> | <WorkExperience> | <TrainingCourse> |
	When the Applicant withdraw the application
	Then the vacancy should not be displayed in Recruit

	Examples:
		| location                    | anonymity | DisabilityConfident | ApplicationMethod | ApprenticeshipType | HoursPerWeek | VacancyDuration | Changeteam    | ChangeRole       | NoOfPositions | QualificationDetails | WorkExperience | TrainingCourse |
		| Set as a nationwide vacancy | Yes       | Yes                 | Online            | Standard           | 42           | 52              | West Midlands | Vacancy reviewer | 3             | Yes                  | No             | No             |