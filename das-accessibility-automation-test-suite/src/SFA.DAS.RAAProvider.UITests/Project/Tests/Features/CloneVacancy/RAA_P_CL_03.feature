Feature: RAA_P_CL_03

@raa
@raaprovider
@clonevacancy
@regression
Scenario: RAA_E_CL_03 - Clone, Approve and Close an advert
	Given the Provider clones and creates an advert
	And the Reviewer Approves the vacancy
	Then the Provider can close the vacancy
