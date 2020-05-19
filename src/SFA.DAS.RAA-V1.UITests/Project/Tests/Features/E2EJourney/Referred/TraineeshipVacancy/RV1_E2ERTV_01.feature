Feature: RV1_E2ERTV_01

@raa-v1
@regression
Scenario Outline: RV1_E2ERTV_01 - Referring a Traineship Vacancy with comments
	Given the Provider initiates Create Apprenticeship Vacancy in Recruit
	When the Provider chooses the employer '<location>','2'
	And the Provider chooses their 'Yes'
	And the Vacancy details are filled out for a Traineeship for a different '<location>'
	Then Provider is able to submit the vacancy for approval
	When the Reviewer refer a vacancy with comments
	Then the vacancy status should be Referred in Recruit

	Examples:
		| location                    | QualificationDetails | WorkExperience | TrainingCourse |
		| Set as a nationwide vacancy | No                   | No             | No             |