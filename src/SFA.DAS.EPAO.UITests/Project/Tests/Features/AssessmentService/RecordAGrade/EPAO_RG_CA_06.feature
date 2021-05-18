Feature: EPAO_RG_CA_06

@epao
@recordagrade
@regression
@epaoca1standard1version0option
Scenario: EPAO_RG_CA_06 - Certify an Apprentice as Pass - 1 Standard - 1 Version - No Options
	Given the Assessor User is logged into Assessment Service Application
	When the User goes through certifying an Apprentice as 'pass' who has enrolled for '1' standard with '1' version and '0' options
	Then the Assessment is recorded and the User is able to navigate back to certifying another Apprentice

