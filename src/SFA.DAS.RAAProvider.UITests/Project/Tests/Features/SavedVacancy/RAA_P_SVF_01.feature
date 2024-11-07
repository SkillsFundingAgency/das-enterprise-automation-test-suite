Feature: RAA_P_SVF_01

@raa
@raaprovider
@regression
@faa
Scenario: RAA_P_SVF_01 - Save a vacancy on vacancy details page
	Given the Provider creates a vacancy by using a registered name
	When the Reviewer Approves the vacancy
	Then the applicant can save on vacancy details page before applying for the vacancy
	And the Applicant can apply for a Vacancy in FAA
