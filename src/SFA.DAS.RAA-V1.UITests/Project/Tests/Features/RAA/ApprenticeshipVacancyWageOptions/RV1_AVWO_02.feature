Feature: RV1_AVWO_02

@raa-v1
@v1_e2e
@regression
@apprenticeshipvacancy
@hema
Scenario Outline: RV1_AVWO_02 - Post Apprenticeship Vacancy Based On Location and Wage
	Given the Provider initiates Create Apprenticeship Vacancy in Recruit
	When the Provider chooses the employer '<location>','<NoOfPositions>'
	And the Provider chooses their 'Yes'
	And the Provider fills out details based on WageType '<location>','<WageType>'
	Then Provider is able to submit the vacancy for approval

	Examples:
		| location               | WageType   | NoOfPositions |
		| Add different location | Fixed wage | 3             |


@raa-v1
@v1_e2e
@regression
@apprenticeshipvacancy
@hema
  Scenario Outline: RV1_AVWO_03 - Post Apprenticeship Vacancy Based On Location and Wage
	Given the Provider initiates Create Apprenticeship Vacancy in Recruit
	When the Provider chooses the employer '<location>','<NoOfPositions>'
	And the Provider chooses their 'Yes'
	And the Provider fills out details based on WageType '<location>','<WageType>'
	Then Provider is able to submit the vacancy for approval

	Examples:
		| location               | WageType   | NoOfPositions |
		| Add different location | Fixed wage | 3             |


@raa-v1
@v1_e2e
@regression
@apprenticeshipvacancy
@hema
  Scenario Outline: RV1_AVWO_03 - Post Apprenticeship Vacancy Based On Location and Wage
	Given the Provider initiates Create Apprenticeship Vacancy in Recruit
	When the Provider chooses the employer '<location>','<NoOfPositions>'
	And the Provider chooses their 'Yes'
	And the Provider fills out details based on WageType '<location>','<WageType>'
	Then Provider is able to submit the vacancy for approval

	Examples:
		| location               | WageType   | NoOfPositions |
		| Add different location | Fixed wage | 3             |


@raa-v1
@v1_e2e
@regression
@apprenticeshipvacancy
@hema
  Scenario Outline: RV1_AVWO_04 - Post Apprenticeship Vacancy Based On Location and Wage
	Given the Provider initiates Create Apprenticeship Vacancy in Recruit
	When the Provider chooses the employer '<location>','<NoOfPositions>'
	And the Provider chooses their 'Yes'
	And the Provider fills out details based on WageType '<location>','<WageType>'
	Then Provider is able to submit the vacancy for approval

	Examples:
		| location               | WageType   | NoOfPositions |
		| Add different location | Fixed wage | 3             |
