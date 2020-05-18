Feature: RV1_RAA_AVWO_01

@raa-v1
@v1_e2e
@regression
@apprenticeshipvacancy
Scenario Outline: RV1_RAA_AVWO_01 - Post Apprenticeship Vacancy Based On Location and Wage
	Given the Provider initiates Create Apprenticeship Vacancy in Recruit
	When the Provider chooses the employer '<location>','<NoOfPositions>'
	And the Provider chooses their 'Yes'
	And the Provider fills out details based on WageType '<location>','<WageType>'
	Then Provider is able to submit the vacancy for approval

	Examples:
		| location                      | WageType              | NoOfPositions |
		| Use the main employer address | National Minimum Wage | 2             |