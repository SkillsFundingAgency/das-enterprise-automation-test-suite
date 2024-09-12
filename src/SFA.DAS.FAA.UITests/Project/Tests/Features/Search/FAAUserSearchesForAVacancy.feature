Feature: FAA_UserSearchesForAVacancy_01

A short summary of the feature

@tag1
Scenario: FAA_USFV_01 User Searches For A Vacancy
	Given the candidate can login in to faa
	When the candidate does a what and where search
	Then the candidate is presented with search results page
	And the Applicant can apply for a Vacancy in FAA
