Feature: RAA_P_CVS_02

@raa		
@raaprovider
@regression
Scenario: RAA_P_CVS_02 - Create, Approve and Edit the advert
	Given the Provider creates a vacancy by using a registered name
	And the Reviewer Approves the vacancy
	When the Applicant can apply for a Vacancy in FAA
	Then the Provider can edit the vacancy
