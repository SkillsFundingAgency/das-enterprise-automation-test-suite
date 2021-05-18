Feature: EPAO_AS_CA_07

@epao
@assessmentservice
@recordagrade
@regression
@epaoca2standard2version1option
Scenario: EPAO_AS_CA_07 - Certify an Apprentice who has enrolled for a multiple standard version and option
	Given the Assessor User is logged into Assessment Service Application
	When the User goes through certifying an Apprentice as 'Passed' who has enrolled for 'multiple' standard
	Then the Assessment is recorded and the User is able to navigate back to certifying another Apprentice