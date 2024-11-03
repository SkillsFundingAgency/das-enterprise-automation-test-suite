Feature: RAA_P_SVF_01

A short summary of the feature

@tag1
Scenario: RAA_P_SVF_01 - Save a vacancy on search results page
	Given the Provider creates a vacancy by using a registered name
	When the Reviewer Approves the vacancy
	Then the applicant can save before applying for the vacancy
	And the Applicant can apply for a Vacancy in FAA
