Feature: RAA_E_CVS_03

@raa		
@raaemployer
@regression
Scenario: RAA_E_CVS_03 - Create, Approve and Close the advert before applying
	Given the Employer creates an advert by using a trading name
	And the Reviewer Approves the vacancy
	Then the Employer can close the vacancy

