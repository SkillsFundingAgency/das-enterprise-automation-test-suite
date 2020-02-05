Feature: FAA_DA_01
	
Background: 
	When an Applicant initiates Account creation journey
	Then the Applicant is able to create a FAA Account
@raa-v1	
@apprenticeshipvacancy
@regression
Scenario Outline: FAA_DA_01  - create a new account in FAA, apply for a vacancy and Delete the Account 
	Given the Provider initiates Create Apprenticeship Vacancy in Recruit
	When the Provider chooses the employer '<location>','<NoOfPositions>'
	And the Provider chooses their '<anonymity>'
	And the Provider fills out details for an Offline Vacancy '<location>','<DisabilityConfident>','<ApplicationMethod>','<ApprenticeshipType>','<HoursPerWeek>','<VacancyDuration>'
	Then Provider is able to submit the vacancy for approval
	And the Reviewer approves the vacancy	
	When the Applicant apply for a Vacancy in New FAA Account '<QualificationDetails>','<WorkExperience>','<TrainingCourse>'
	Then the Provider is able to search and select a New Candidate
	And the reviewer is able to search and select a New candidate
	When Applicant Deletes the FAA Account
	Then the Candidate is removed from the Recruit
	And the Candidate is removed from the Manage

	Examples:
		| location               | anonymity | DisabilityConfident | ApplicationMethod | ApprenticeshipType | HoursPerWeek | VacancyDuration | NoOfPositions | QualificationDetails | WorkExperience | TrainingCourse |
		| Add different location | Yes       | Yes                 | Online            | Standard           | 42           | 52              | 3             | No                   | Yes            | No             |