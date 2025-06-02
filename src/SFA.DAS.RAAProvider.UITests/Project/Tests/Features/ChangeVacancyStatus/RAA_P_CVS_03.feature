Feature: RAA_P_CVS_03

@raa		
@raaprovider
@regression
Scenario: RAA_P_CVS_03 - Create, Approve and Close the vacancy before applying
	Given the Provider creates a vacancy by using a registered name
	And the Reviewer Approves the vacancy
	Then the Provider can close the vacancy

