Feature: EPAO_RG_CA_04

@epao
@recordagrade
@regression
@epaoca1standard2version1option
Scenario: EPAO_RG_CA_04 - Certify an Apprentice as Pass - 1 Standard - Multiple Version - With Options
	Given the Assessor User is logged into Assessment Service Application
	When the User certifies an Apprentice as 'pass'
	Then the Assessment is recorded and the User is able to navigate back to certifying another Apprentice

