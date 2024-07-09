Feature: RAA_E_CL_04

@raa
@raaemployer
@clonevacancy
@regression
Scenario: RAA_E_CL_04 - Clone, Approve and Edit an advert
	Given the Employer clones and creates an advert
	And the Reviewer Approves the vacancy
	Then the Employer can edit the vacancy
