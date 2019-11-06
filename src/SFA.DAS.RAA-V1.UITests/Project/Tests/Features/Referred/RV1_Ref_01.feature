Feature: RV1_REF_01

A short summary of the feature


Scenario Outline: RV1_REF_01 Refering a vacancy with comments
Given the Provider initiates Create Apprenticeship Vacancy in Recruit
When the Provider chooses the employer '<location>','<NoOfPositions>'
And the Provider chooses their '<anonymity>'
And the Provider fills out details for an Offline Vacancy '<location>','<DisabilityConfident>','<ApplicationMethod>','<ApprenticeshipType>','<HoursPerWeek>','<VacancyDuration>'
Then Provider is able to submit the vacancy for approval
When the Reviewer initiates reviewing the Vacancy in Manage
And the Reviewer refer a vacancy with comments '<Changeteam>','<ChangeRole>'
Then the vacancy status should be Referred in Recruit

Examples: 
| location                      | anonymity | DisabilityConfident | ApplicationMethod | ApprenticeshipType | HoursPerWeek | VacancyDuration | Changeteam    | ChangeRole       |NoOfPositions |
| Use the main employer address | No        | No                  | Online            | Framework          | 42           | 52              | West Midlands | Vacancy reviewer |2             |
