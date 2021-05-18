Feature: EPAO_RG_CA_06

@epao
@recordagrade
@regression
@epaoca2standard1version1option
Scenario: EPAO_RG_CA_06 - Certify an Apprentice as Pass - multiple Standard - 1 Version - with Options
	Given the Assessor User is logged into Assessment Service Application
	When  the User certifies an Apprentice as 'pass' who has enrolled for 'multiple' standard
	Then the Assessment is recorded and the User is able to navigate back to certifying another Apprentice

