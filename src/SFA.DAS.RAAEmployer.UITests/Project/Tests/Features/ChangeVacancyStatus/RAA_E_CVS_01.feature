Feature: RAA_E_CVS_01

@raa		
@raaemployer
@regression
Scenario: RAA_E_CVS_01 - Create, Approve and Close the vacancy
	Given the Employer creates an advert by using a registered name
	And the Reviewer Approves the vacancy
	When the Applicant can apply for a Vacancy in FAA
	Then the Employer can close the vacancy
