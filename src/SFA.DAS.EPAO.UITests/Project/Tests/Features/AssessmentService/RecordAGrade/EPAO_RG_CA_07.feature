Feature: EPAO_RG_CA_07

@epao
@recordagrade
@regression
@epaoca2standard2version0option
Scenario: EPAO_RG_CA_07 - Certify an Apprentice as Pass - multiple Standard - multiple Version - No Options
	Given the Assessor User is logged into Assessment Service Application
	When the User certifies an Apprentice as 'pass'
	Then the Assessment is recorded and the User is able to navigate back to certifying another Apprentice

