Feature: EPAO_RG_CA_03

@epao
@recordagrade
@regression
@epaoca1standard2version0option
Scenario: EPAO_RG_CA_03 - Certify an Apprentice as Pass - 1 Standard - Multiple Version - No Options
	Given the Assessor User is logged into Assessment Service Application
	When  the User certifies an Apprentice as 'pass' who has enrolled for '1' standard
	Then the Assessment is recorded and the User is able to navigate back to certifying another Apprentice

