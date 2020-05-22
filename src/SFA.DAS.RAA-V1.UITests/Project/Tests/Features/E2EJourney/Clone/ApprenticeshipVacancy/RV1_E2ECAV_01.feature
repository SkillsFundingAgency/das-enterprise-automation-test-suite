Feature: RV1_E2ECAV_01

@raa-v1
@v1_e2e
@regression
@apprenticeshipvacancy
Scenario Outline: RV1_E2ECAV_01 - Clone an existing Live Apprenticeship Vacancy, Approve and Apply
	Given the Provider clones an existing vacancy
	Then Provider is able to submit the vacancy for approval
	Then the Reviewer approves the vacancy
	When the Applicant apply for a Vacancy in FAA '<QualificationDetails>','<WorkExperience>','<TrainingCourse>'
	Then the vacancy status should be Live in Recruit

	Examples:
		| QualificationDetails | WorkExperience | TrainingCourse |
		| Yes                  | Yes            | Yes            |