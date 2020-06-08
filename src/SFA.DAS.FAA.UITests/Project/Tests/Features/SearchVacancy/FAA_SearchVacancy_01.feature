Feature: FAA_SearchVacancy_01

@faa
@raa-v1
@regression
Scenario: FAA_SearchVacancy_01 - Search Nationwide Vacancy in FAA and checkin the sort results and distance on the vacancies
	Given an applicant is on the Find an Apprenticeship Page
	When the candidate search for Nationwide Vacancies 'CV1','England'
	Then the Sort results is changed by closing date and distance is not displayed on the vacancies