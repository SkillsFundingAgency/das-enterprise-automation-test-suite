Feature: RV1_RefTV_01

@raa-v1
@regression
Scenario Outline: RV1_RefTV_01 - Referring a Traineship Vacancy with comments
	Given the Provider initiates Create Apprenticeship Vacancy in Recruit
	When the Provider chooses the employer '<location>','2'
	And the Provider chooses their 'Yes'
	And the Vacancy details are filled out for a Traineeship for a different '<location>'
	Then Provider is able to submit the vacancy for approval
	When the Reviewer initiates reviewing the Vacancy in Manage
	And the Reviewer refer a vacancy with comments '<Changeteam>','<ChangeRole>'
	Then the vacancy status should be Referred in Recruit

	Examples:
		| location                    | Changeteam    | ChangeRole       | QualificationDetails | WorkExperience | TrainingCourse |
		| Set as a nationwide vacancy | West Midlands | Vacancy reviewer | No                   | No             | No             |