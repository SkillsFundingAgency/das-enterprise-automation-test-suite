Feature: RAA_E_CL_03

@raa
@raaemployer
@clonevacancy
@regression
Scenario: RAA_E_CL_03 - Clone, Approve and Close an advert
	Given the Employer clones and creates an advert
	And the Reviewer Approves the vacancy
	Then the Employer can close the vacancy
