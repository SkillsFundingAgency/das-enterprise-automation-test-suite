Feature: EPAO_RG_CA_08

@epao
@recordagrade
@regression
@epaoca2standard2version1option
Scenario: EPAO_RG_CA_08 - Certify an Apprentice as Pass - multiple Standard - multiple Version - with Options
	Given the Assessor User is logged into Assessment Service Application
	When  the User certifies an Apprentice as 'pass' who has enrolled for 'multiple' standard
	Then the Assessment is recorded and the User is able to navigate back to certifying another Apprentice

