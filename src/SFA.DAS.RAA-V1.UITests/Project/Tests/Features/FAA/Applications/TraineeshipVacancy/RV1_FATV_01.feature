Feature: RV1_FATV_01

@raa-v1
@regression
@adddifferentlocation
Scenario Outline: RV1_FATV_01 search for an existing traineeship vacancy
	Given the Provider initiates Create Apprenticeship Vacancy in Recruit
	When the Provider chooses the employer '<location>','2'
	And the Provider chooses their 'Yes'
	And the Vacancy details are filled out for a Traineeship for a different '<location>'
	Then Provider is able to submit the vacancy for approval
	Then the Reviewer approves the vacancy
	When an applicant is on the Find an Traineeship Page
	And searched based on 'CV3 5ER'
	Then the traineeship can be found based on 'CV3 1HX','2 miles'
	And the traineeship can be found based on 'CV6 6GE','5 miles'
	And the traineeship can be found based on 'CV11 6QF','10 miles'

	Examples:
		| location               |
		| Add different location |