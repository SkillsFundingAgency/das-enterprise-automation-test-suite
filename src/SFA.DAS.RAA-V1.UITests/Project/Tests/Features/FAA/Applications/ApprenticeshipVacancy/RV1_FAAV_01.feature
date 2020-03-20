@raa-v1
@regression
Feature: RV1_FAAV_01

@raa-v1
@apprenticeshipvacancy
@regression
Scenario Outline: RV1_FAAV_01 search for an existing apprenticeship vacancy
	Given the Provider initiates Create Apprenticeship Vacancy in Recruit
	When the Provider chooses the employer '<location>','<NoOfPositions>'
	And the Provider chooses their '<anonymity>'
	And the Provider fills out details for an Offline Vacancy '<location>','<DisabilityConfident>','<ApplicationMethod>','<ApprenticeshipType>','<HoursPerWeek>','<VacancyDuration>'
	Then Provider is able to submit the vacancy for approval
	Then the Reviewer approves the vacancy
	When an applicant is on the Find an Apprenticeship Page
	Then the apprenticeship can be found based on 'E1 7LL','2 miles'
	And the apprenticeship can be found based on 'SE16','5 miles'
	And the apprenticeship can be found based on 'SE9 5QE','15 miles'
	And the apprenticeship can be found based on 'EH4 3AY','England'
	And the apprenticeship can be found based on 'E1 7LL','Job title'
	And the apprenticeship can be found based on 'E1 7LL','Employer'
	And the apprenticeship can be found based on 'E1 7LL','Description'
	
	Examples:
		| location					  | anonymity | DisabilityConfident | ApplicationMethod | ApprenticeshipType | HoursPerWeek | VacancyDuration | NoOfPositions | 
		| Add different location      | Yes       | Yes                 | Online            | Standard           | 42           | 52              | 3             |