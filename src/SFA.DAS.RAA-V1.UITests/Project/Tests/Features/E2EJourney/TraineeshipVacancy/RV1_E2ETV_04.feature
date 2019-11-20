Feature: RV1_E2ETV_04

@raa-v1
@v1_e2e
@regression
Scenario Outline: RV1_E2ETV_04 - Create an offline Traineeship Vacancy
	Given the Provider initiates Create Apprenticeship Vacancy in Recruit
	When the Provider chooses the employer '<location>','2'
	And the Provider chooses their 'Yes'
	And an offline Vacancy details are filled out for a Traineeship for a different '<location>'
	Then Provider is able to submit the vacancy for approval
	
	Examples:
		| location                      | Changeteam    | ChangeRole       | QualificationDetails | WorkExperience | TrainingCourse |
		| Use the main employer address | West Midlands | Vacancy reviewer | No                   | No             | No             |