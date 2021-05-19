Feature: EPAO_RG_CA_05

@epao
@recordagrade
@regression
@epaoca2standard1version0option
Scenario: EPAO_RG_CA_05 - Certify an Apprentice as Pass - Multiple Standard - 1 Version - No Options
	Given the Assessor User is logged into Assessment Service Application
	When the User certifies an Apprentice as 'pass'
	Then the Assessment is recorded and the User is able to navigate back to certifying another Apprentice

