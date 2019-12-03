Feature: RV1_WDAV_01

@raa-v1
@regression
@apprenticeshipvacancy
Scenario Outline: RV1_WDAV_01 - Withdraw Apprenticeship Vacancy
	Given the apprenticeship vacancy is Live in Recruit
		| location   | anonymity   | DisabilityConfident   | ApplicationMethod   | ApprenticeshipType   | HoursPerWeek   | VacancyDuration   | NoOfPositions   | QualificationDetails   | WorkExperience   | TrainingCourse   |
		| <location> | <anonymity> | <DisabilityConfident> | <ApplicationMethod> | <ApprenticeshipType> | <HoursPerWeek> | <VacancyDuration> | <NoOfPositions> | <QualificationDetails> | <WorkExperience> | <TrainingCourse> |
	When the Applicant withdraw the application
	Then the vacancy should not be displayed in Recruit

	Examples:
		| location                    | anonymity | DisabilityConfident | ApplicationMethod | ApprenticeshipType | HoursPerWeek | VacancyDuration | NoOfPositions | QualificationDetails | WorkExperience | TrainingCourse |
		| Set as a nationwide vacancy | Yes       | Yes                 | Online            | Standard           | 42           | 52              | 3             | Yes                  | No             | No             |