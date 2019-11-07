Feature: RV1_WD_01

A short summary of the feature

@Vacancy
Scenario Outline: Withdraw Vacancy
	Given the vacancy is Live in Recruit
	| location   | anonymity   | DisabilityConfident   | ApplicationMethod   | ApprenticeshipType   | HoursPerWeek   | VacancyDuration   | Changeteam   | ChangeRole   | NoOfPositions   | QualificationDetails   | WorkExperience   | TrainingCourse   |
	| <location> | <anonymity> | <DisabilityConfident> | <ApplicationMethod> | <ApprenticeshipType> | <HoursPerWeek> | <VacancyDuration> | <Changeteam> | <ChangeRole> | <NoOfPositions> | <QualificationDetails> | <WorkExperience> | <TrainingCourse> |
	When the Applicant withdraw the application
	Then the vacancy should not be displayed in Recruit

Examples:
| location                    | anonymity | DisabilityConfident | ApplicationMethod | ApprenticeshipType | HoursPerWeek | VacancyDuration | Changeteam    | ChangeRole       | NoOfPositions | QualificationDetails | WorkExperience | TrainingCourse |
| Set as a nationwide vacancy | Yes       | Yes                 | Online            | Standard           | 42           | 52              | West Midlands | Vacancy reviewer | 3             | Yes                  | No             | No             |

