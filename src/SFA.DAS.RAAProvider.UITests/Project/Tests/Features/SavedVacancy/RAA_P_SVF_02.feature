Feature: RAA_P_SVF_02

@raa
@raaprovider
@regression
@faa
Scenario: RAA_P_SVF_02 - Save a vacancy on search results page
	Given the Provider creates a vacancy by using a registered name
	When the Reviewer Approves the vacancy
	Then the applicant can save vacancy on search results page before applying for the vacancy
	And the Applicant can apply for a Vacancy in FAA