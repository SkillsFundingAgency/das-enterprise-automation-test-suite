Feature: RV1_RefAV_01

@raa-v1
@regression
@apprenticeshipvacancy
Scenario Outline: RV1_RefAV_01 - Referring an Apprenticeship Vacancy with comments
	Given the Provider initiates Create Apprenticeship Vacancy in Recruit
	When the Provider chooses the employer '<location>','<NoOfPositions>'
	And the Provider chooses their '<anonymity>'
	And the Provider fills out details for an Offline Vacancy '<location>','<DisabilityConfident>','<ApplicationMethod>','<ApprenticeshipType>','<HoursPerWeek>','<VacancyDuration>'
	Then Provider is able to submit the vacancy for approval
	When the Reviewer refer a vacancy with comments
	Then the vacancy status should be Referred in Recruit

	Examples:
		| location                      | anonymity | DisabilityConfident | ApplicationMethod | ApprenticeshipType | HoursPerWeek | VacancyDuration | NoOfPositions |
		| Use the main employer address | No        | No                  | Online            | Framework          | 42           | 52              | 2             |