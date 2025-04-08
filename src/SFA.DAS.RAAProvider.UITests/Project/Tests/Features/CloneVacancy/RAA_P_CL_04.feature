Feature: RAA_P_CL_04

@raa
@raaprovider
@clonevacancy
@regression
Scenario: RAA_E_CL_04 - Clone, Approve and Edit an advert
	Given the Provider clones and creates an advert
	And the Reviewer Approves the vacancy
	Then the Provider can edit the vacancy
