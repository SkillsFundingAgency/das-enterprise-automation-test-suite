Feature: RV1_CAV_02

@raa-v1
@v1_e2e
@regression
@apprenticeshipvacancy
Scenario Outline: RV1_CAV_02 - Clone an existing Live Apprenticeship Vacancy, Approve and Apply
	Given the Provider clones an existing vacancy
	Then Provider is able to submit the vacancy for approval
	Then the Reviewer approves the vacancy
	When the Applicant apply for a Vacancy in FAA '<QualificationDetails>','<WorkExperience>','<TrainingCourse>'
	Then the vacancy status should be Live in Recruit

	Examples:
		| QualificationDetails | WorkExperience | TrainingCourse |
		| No                   | No             | No             |