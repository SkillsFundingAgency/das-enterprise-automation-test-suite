Feature: RAA_E_CVS_02

@raa		
@raaemployer
@regression
Scenario: RAA_E_CVS_02 - Create, Approve and Edit the advert
	Given the Employer creates an advert by using a trading name
	And the Reviewer Approves the vacancy
	Then the Employer can edit the vacancy
