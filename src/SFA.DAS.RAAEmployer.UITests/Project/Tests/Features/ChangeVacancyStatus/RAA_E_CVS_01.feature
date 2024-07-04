Feature: RAA_E_CVS_01

@raa		
@raaemployer
@regression
Scenario: RAA_E_CVS_01 - Create, Approve and Close the vacancy
	Given the Employer can create an advert by entering all the Optional fields
	And the Reviewer Approves the vacancy
	Then the Employer can close the vacancy
