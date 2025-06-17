Feature: RAA_P_CVS_01

@raa		
@raaprovider
@regression
Scenario: RAA_P_CVS_01 - Create, Approve and Close the vacancy
	Given the Provider creates a vacancy by using a registered name
	And the Reviewer Approves the vacancy
	When the Applicant can apply for a Vacancy in FAA
	Then the Provider can close the vacancy
