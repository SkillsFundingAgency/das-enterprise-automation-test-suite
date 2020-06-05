Feature: RV1_E2ETV_01

@raa-v1
@v1_e2e
@adddifferentlocation
@regression
Scenario Outline: RV1_E2ETV_01 - Create, Approve and Apply for a Traineeship Vacancy and View Anonymous
	Given the Provider initiates Create Apprenticeship Vacancy in Recruit
	When the Provider chooses the employer '<location>','2'
	And the Provider chooses their 'Yes'
	And the Vacancy details are filled out for a Traineeship for a different '<location>'
	Then Provider is able to submit the vacancy for approval
	Then the Reviewer approves the vacancy
	When the Applicant apply for a Vacancy in FAA '<QualificationDetails>','<WorkExperience>','<TrainingCourse>'
	Then the vacancy can be viewed anonymously

	Examples:
		| location               | QualificationDetails | WorkExperience | TrainingCourse |
		| Add different location | No                   | No             | No             |